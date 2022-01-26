using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject[] enemies;
    public Camera camera;

    // Enable this room
    public void Enable()
    {
        this.camera.enabled = true;
        this.enabled = true;
    }

    // Disable this room
    public void Disable()
    {
        this.camera.enabled = false;
        this.enabled = false;
    }

    // Prepare room for new visit
    public void Reset()
    {
        
    }
}
