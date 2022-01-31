using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;

    private void OnEnable()
    {
        Reset();
    }

    // Prepare room for new visit
    public void Reset()
    {
        Debug.Log("TODO: Room reset");
    }
}
