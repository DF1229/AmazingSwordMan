using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool hasEnemies = true;
    public bool infiniteWaves = false;

    private int currWave = 0;
    public Wave[] waves;

    public bool finished = false;
    public GameObject particles;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        Reset();
    }

    public void nextWave()
    {
        waves[currWave].Activate();
        currWave++;

        if (currWave > waves.Length)
        {
            Finished();
        }
    }

    private void Finished()
    {
        this.finished = true;
        particles.SetActive(true);
    }

    // Prepare room for new visit
    public void Reset(bool force = false)
    {
        if (!force)
        {
            if (infiniteWaves)
                Reset(true);

            if (!hasEnemies)
                return;
        } else
        {
            currWave = 0;

            foreach (Wave wave in waves)
            {
                wave.Reset();
            }
        }
    }
}