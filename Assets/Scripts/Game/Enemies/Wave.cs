using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public SpawnPoint[] spawnPoints;

    public void Activate()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            spawnPoint.Activate();
        }
    }

    public void Reset()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            spawnPoint.Reset();
        }
    }
}
