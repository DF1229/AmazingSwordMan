using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Enemy enemyToSpawn;

    public void Activate()
    {
        enemyToSpawn.gameObject.SetActive(true);
    }

    public void Reset()
    {
        enemyToSpawn.Reset();
    }
}
