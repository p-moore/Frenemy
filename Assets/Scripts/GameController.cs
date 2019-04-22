using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    static public int NUMBEROFPLAYERS = 4;
    static public int NUMBEROFPLAYERSALIVE;
    static public int NUMBEROFLIVES = 3;
    static public GameObject[] player = new GameObject[4];
    static public int[] lives = new int[4];
    static public int[] playerClass = new int[4];
    static public int idOfWinner = 1;
    public BossController bossTemplate;
    public PlayerController[] classTemplates; 
    public Transform[] spawnPoints;
    public Transform bossSpawnPoint;
    bool bossSpawned = false;

    //float timeUntilBoss = 5f;
    float bossTimer = 30f;

    public CameraFollow Camera;



    private bool checkGameover()
    {
        if (NUMBEROFPLAYERSALIVE == 1) { return true; }
        return false;
    }
    public void spawnPlayers()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            PlayerController tempPlayer = Instantiate(classTemplates[playerClass[i]], spawnPoints[i].position, spawnPoints[i].rotation);
            tempPlayer.id = i + 1;
            Camera.targets.Add(tempPlayer.transform);
            lives[i] = NUMBEROFLIVES;
            NUMBEROFPLAYERSALIVE++;
        }
    }

    public void Respawn(int id)
    {
        if(lives[id-1] >= 0)
        {
            PlayerController tempPlayer = Instantiate(classTemplates[playerClass[id - 1]], spawnPoints[id - 1].position, spawnPoints[id - 1].rotation);
            tempPlayer.id = id;
            Camera.targets.Add(tempPlayer.transform);
            lives[id - 1]--;
        }
        else{
            NUMBEROFPLAYERSALIVE--;
            if (checkGameover()) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
        }
    }

    public void SpawnBoss()
    {
        BossController Boss = Instantiate(bossTemplate, bossSpawnPoint.position, bossSpawnPoint.rotation);
        bossSpawned = true;
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

    void Update()
    {
        if(bossTimer <= 0 && bossSpawned == false)
        {
            SpawnBoss();
        }
        else
        {
            bossTimer -= Time.deltaTime;
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
