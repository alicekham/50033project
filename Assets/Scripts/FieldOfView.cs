using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public GameObject motherBody;
    private Mesh mesh;
    private float fov;
    private Vector3 origin;
    private float startingAngle;
    private GameObject ghostBody;
    public UnityEvent onDamageGhost;
    public UnityEvent onStopDamageGhost;
    private bool ghostDetected = false;


    // Start is called before the first frame update
    private void Start() {
        ghostBody = GameObject.FindGameObjectsWithTag("Ghost")[0];
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        //Vector3 parentPosition = motherBody.transform.position;
        origin = Vector3.zero;
    }

    private void LateUpdate()
    {
        int rayCount = 25;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 2.5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;
        int countNumRayDectectsGhost = 0;
        for (int i = 0; i <= rayCount; i++) {
            float angleRad = angle * (Mathf.PI / 180f);
            Vector3 vecfromangle = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, vecfromangle, viewDistance, layerMask);
            if (raycastHit2D.collider == null) {
                // FOV does not hit obstacle

                vertex = origin + vecfromangle * viewDistance;
                //Debug.Log("No hit");
                
                
            }
            else if (raycastHit2D.collider == ghostBody.GetComponent<BoxCollider2D>())
            {
                vertex = origin + vecfromangle * viewDistance;
                countNumRayDectectsGhost++;
                //Debug.Log("Yes");
                if (ghostDetected == false)
                {
                    onDamageGhost.Invoke();
                    ghostDetected = true;
                    
                   
                }

            }
            else {
                // FOV hits obstacle
                //Debug.Log(raycastHit2D.collider);
                vertex = raycastHit2D.point;
                //Debug.Log("Hit");
                
            }

            if (countNumRayDectectsGhost == 0 & ghostDetected == true)
            {
                onStopDamageGhost.Invoke();
                ghostDetected = false;
                
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        //Debug.Log(origin);
    }

    public void SetOrigin(Vector3 org) {
        this.origin = org;
    }
    public void SetDirection(Vector3 dirn) {
        dirn = dirn.normalized;
        startingAngle = Mathf.Atan2(dirn.y, dirn.x) * Mathf.Rad2Deg;
        //Debug.Log(startingAngle);
        if (startingAngle < 0) startingAngle += 360;
        startingAngle += fov / 2f;
    }
}