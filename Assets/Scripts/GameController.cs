using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static public int NUMBEROFPLAYERS;
    static public int[] player = new int[4];
    static public int[] playerClass = new int[4];
    public PlayerController[] classTemplates; 
    public Transform[] spawnPoints;
    public CameraFollow Camera;


    public void spawnPlayers()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            PlayerController tempPlayer = Instantiate(classTemplates[playerClass[i]], spawnPoints[i].position, spawnPoints[i].rotation);
            tempPlayer.id = i + 1;
            Camera.targets.Add(tempPlayer.transform);
        }
    }
    //For Charecter Slection
    //index 0 is player 1
    //Class 0 = EGI
    //Class 1 = SPY
    //Class 2 = SCI
    //Class 3 = SOL
    void Start()
    {
        Camera = FindObjectOfType<CameraFollow>();
        if(spawnPoints[0] != null)
        {
            spawnPlayers();
        }
    }

    public void PlayerOneClassSwitch(int newPlayerClass)
    {
        playerClass[0] = newPlayerClass;
    }
    public void PlayerTwoClassSwitch(int newPlayerClass)
    {
        playerClass[1] = newPlayerClass;
    }
    public void PlayerThreeClassSwitch(int newPlayerClass)
    {
        playerClass[2] = newPlayerClass;
    }
    public void PlayerFourClassSwitch(int newPlayerClass)
    {
        playerClass[3] = newPlayerClass;
    }

}
