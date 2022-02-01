using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connection;
    public Room currentRoom;
    public Room nextRoom;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 newPos = new Vector3(connection.position.x, connection.position.y, other.transform.position.z);
        other.transform.position = newPos;

        currentRoom.gameObject.SetActive(false);
        nextRoom.gameObject.SetActive(true);

        Player player = other.GetComponent<Player>();
        if (player)
            player.currRoom = nextRoom;
    }
}
