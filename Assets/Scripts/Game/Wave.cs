using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public SpawnPoint[] spawnPoints;

    public void Activate()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
            spawnPoint.Activate();
    }

    public void Reset()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
            spawnPoint.Reset();
    }

    public List<Enemy> GetActiveEnemies()
    {
        List<Enemy> activeEnemies = new List<Enemy>();
        foreach (SpawnPoint spawnPoint in spawnPoints)
            if (spawnPoint.enemyToSpawn.gameObject.activeSelf)
                activeEnemies.Add(spawnPoint.enemyToSpawn);

        return activeEnemies;
    }
}
