using System.Collections.Generic;
using UnityEngine;
using System;

public class Room : MonoBehaviour
{
    public bool hasEnemies = true;
    public bool infiniteWaves = false;

    private int currWave = 0;
    public Wave[] waves;

    public bool finished = false;
    public GameObject particles;

    private void OnEnable()
    {
        Reset();
    }

    private void OnDisable()
    {
        Reset();
    }

    public void nextWave()
    {
        if (!hasEnemies)
            return;

        try
        {
            waves[currWave].Activate();
            currWave++;
        }
        catch (IndexOutOfRangeException)
        {
            if (!infiniteWaves)
                Finished();
            else
                Reset();
        }
    }

    private void Finished()
    {
        this.finished = true;
        if (!particles.activeSelf)
            particles.SetActive(true);
    }

    public List<Enemy> GetActiveEnemies()
    {
        List<Enemy> activeEnemies = new List<Enemy>();

        foreach (Wave wave in waves)
            activeEnemies.AddRange(wave.GetActiveEnemies());

        return activeEnemies;
    }

    // Prepare room for new visit
    public void Reset()
    {
        if (!hasEnemies)
            return;

        currWave = 0;
        finished = false;

        foreach (Wave wave in waves)
            wave.Reset();

        nextWave();
    }
}