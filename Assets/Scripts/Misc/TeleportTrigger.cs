using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{

    public Transform location;
    private Vector2 teleportPosition;

    void Awake()
    {
        teleportPosition = location.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
        Debug.Log("To teleport:" + teleportPosition);
        other.transform.position = teleportPosition;
        }
    }
}
