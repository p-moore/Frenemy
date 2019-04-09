using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //This array refers to the chosen classes of the players.
    //For example if playerClass[0] == 1
    //it means that player 1 has chosen the Spy class.
    //The contents of this array should be changed in the Charecter select 
    //Stage
    static int[] playerClass = new int[4];

    //Number of total players in game
    static int NumberOfPlayers;

    //Spawnpoints for the given level
    //Stored inside the level prefab
    //Attached at somepoint
    [SerializeField] Transform[] spawnPoint;

    //Classes holds the actual player objects to be spawned
    //0 - Engi
    //1 - Spy
    //2 - Sci
    //3 - Sol
    public PlayerController[] classes;


    //Creates players
    //Attaches them to the camera for tracking
    private void SpawnPlayers()
    {
        for(int i = 0; i < NumberOfPlayers; i++)
        {

        }
    }

    private void Awake()
    {

    }

}
