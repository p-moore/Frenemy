using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject[] playerObjects;
    public PlayerController[] Players = new PlayerController[4];

    void DeactivateScene()
    {
        playerObjects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i<playerObjects.Length; i++)
        {
            Players[i] = playerObjects[i].GetComponent<PlayerController>();
            Players[i].enabled = false;
        }
    }


    void ActivateScene()
    {
        for (int i = 0; i < playerObjects.Length; i++)
        {
            Players[i].enabled = true;
        }
    }

    void KillMe()
    {
        Destroy(this.gameObject);
    }



}
