using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    // for Scoring system
    int currentScore;

    // for Spirit Bar
    public int Max_Spirit = 100;
    public float currentPlayerSpirit = 100f;
    public float spirit_DecreaseRate = 30f;

    // for Energy Bar
    public int Max_Energy = 100;
    public float currentPlayerEnergy = 100f;
    public float energy_DecreaseRate = 30f;

    // for Reset values
    //Vector3 gombaSpawnPointStart = new Vector3(2.5f, -0.45f, 0); // hardcoded location
    // .. other reset values 

    // for Consume.cs
    //public int consumeTimeStep = 10;
    //public int consumeLargestScale = 4;

    // for Break.cs
    //public int breakTimeStep = 30;
    //public int breakDebrisTorque = 10;
    //public int breakDebrisForce = 10;

    // for SpawnDebris.cs
    //public int spawnNumberOfDebris = 10;

    // for Rotator.cs
    //public int rotatorRotateSpeed = 6;

    // for testing
    //public int testValue;

    //Body Boolean
    public bool isMother = false;
    public bool isButler = false;
    public bool isSister = false;

}
