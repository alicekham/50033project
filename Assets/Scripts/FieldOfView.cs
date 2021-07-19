using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private float fov;
    private Vector3 origin;
    private float startingAngle;

    // Start is called before the first frame update
    private void Start() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        origin = Vector3.zero;
    }

    private void LateUpdate()
    {
        int rayCount = 25;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 1.5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) {
            float angleRad = angle * (Mathf.PI / 180f);
            Vector3 vecfromangle = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, vecfromangle, viewDistance, layerMask);
            if (raycastHit2D.collider == null) {
                // FOV does not hit obstacle
                vertex = origin + vecfromangle * viewDistance;
            } else {
                // FOV hits obstacle
                vertex = raycastHit2D.point;
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
    }

    public void SetOrigin(Vector3 origin) {
        this.origin = origin;
    }
    public void SetDirection(Vector3 dirn) {
        dirn = dirn.normalized;
        startingAngle = Mathf.Atan2(dirn.y, dirn.x) * Mathf.Rad2Deg;
        if (startingAngle < 0) startingAngle += 360;
        startingAngle += fov / 2f;
    }
}