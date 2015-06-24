//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    //dont destroy on load
    //OnLevelWasLoaded


    //ich muß die gefundenen GameObjects aktivieren!!!!!
    //To set the Playerquantity
    public static bool setToSinglePlayer;
    public static bool setToTwoPlayers;
    public static bool setToThreePlayers;
    public static bool setToFourPlayers;

    private bool paused = false;

    public static GameObject camera_1;
    public static GameObject camera_2;
    public static GameObject camera_3;
    public static GameObject camera_4;
    private GameObject mainCamera;

    public static GameObject player_1;
    public static GameObject player_2;
    public static GameObject player_3;
    public static GameObject player_4;
    //public static List<GameObject> playerList;

    public GameObject powerUp;
    public int maxPowerUps = 6;
    private int currentNrOfPowerUps;
    private List<Vector3> powerUpSpawnPoints;
    private Vector3 lastSpawnPoint;
    private Vector3 nextSpawnPoint;
    private int spawnTimer;
    private int minSpawnDelay;
    private int maxSpawnDelay;
    
    
    void Awake ()
    {
        FindPlayers();
        FindCameras();
        //When Load Level
        FindPowerUpSpawnPoints();
    }
	
	void Update () 
    {
        //if "anyKey works like i hope, i must test when the Class works. (4.6.2015)
        if (Input.anyKeyDown)
        {
            Pause();
            PlayerQuantitySelection();
            Debug.Log("KeyHitInUpdate");
        }
        SetPowerUps();
	}

    void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            Pause();
            Debug.Log("KeyHitInFixedUpdate");
        }
    }

    void LateUpdate()
    {

    }

    //Little Function to test the PlayerQuantitySelection and the Activation of Players and Cameras. (4.6.2015)
    void PlayerQuantitySelection()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            setToSinglePlayer = true;
            ActivatePlayers();
            ActivateCameras();
        }
        else if (Input.GetKey(KeyCode.F2))
        {
            setToTwoPlayers = true;
            ActivatePlayers();
            ActivateCameras();
        }
        else if (Input.GetKey(KeyCode.F3))
        {
            setToThreePlayers = true;
            ActivatePlayers();
            ActivateCameras();
        }
        else if (Input.GetKey(KeyCode.F4))
        {
            setToFourPlayers = true;
            ActivatePlayers();
            ActivateCameras();
        }
    }

    //Find over Tags the Player GameObjects after the PlayerQuantity is selected. (5.6.2015)
    void FindPlayers()
    {
        player_1 = GameObject.FindGameObjectWithTag("P_1");
        player_2 = GameObject.FindGameObjectWithTag("P_2");
        player_3 = GameObject.FindGameObjectWithTag("P_3");
        player_4 = GameObject.FindGameObjectWithTag("P_4");

        DeActivatePlayers();
    }

    //Find over Tags the Camera GameObjects. It is outside the "FindPlayer()", because i wana use it later for more Cameras an nother funktions. (5.6.2015)
    //Only active Objects will be find over Tag. I look for a work around, but yet i search all GameObjects and deactivate them.
    void FindCameras()
    {
        mainCamera = GameObject.FindGameObjectWithTag("Main_Camera");
        camera_1 = GameObject.FindGameObjectWithTag("Camera_1");
        camera_2 = GameObject.FindGameObjectWithTag("Camera_2");
        camera_3 = GameObject.FindGameObjectWithTag("Camera_3");
        camera_4 = GameObject.FindGameObjectWithTag("Camera_4");

        DeActivateCameras();
    }

    //Activate the Player GameObjects. This way i can check over an nother bool if a Controller ist conected (5.6.2015)
    void ActivatePlayers()
    {
        if (setToSinglePlayer)
        {
            player_1.SetActive(true);
        }
        else if (setToTwoPlayers)
        {
            player_1.SetActive(true);
            player_2.SetActive(true);
        }
        else if (setToThreePlayers)
        {
            player_1.SetActive(true);
            player_2.SetActive(true);
            player_3.SetActive(true);
        }
        else if (setToFourPlayers)
        {
            player_1.SetActive(true);
            player_2.SetActive(true);
            player_3.SetActive(true);
            player_4.SetActive(true);
        }
    }

    //Activate the Cameras GameObjects. If Game Paused, i can controll what the Players see in this time (5.6.2015)
    void ActivateCameras()
    {
        if (paused == false)
        {
            if (setToSinglePlayer)
            {
                camera_1.SetActive(true);
            }
            else if (setToTwoPlayers)
            {
                camera_1.SetActive(true);
                camera_2.SetActive(true);
            }
            else if (setToThreePlayers)
            {
                camera_1.SetActive(true);
                camera_2.SetActive(true);
                camera_3.SetActive(true);
            }
            else if (setToFourPlayers)
            {
                camera_1.SetActive(true);
                camera_2.SetActive(true);
                camera_3.SetActive(true);
                camera_4.SetActive(true);
            }

            mainCamera.SetActive(false);
        }

        else if (paused)
        {
            camera_1.SetActive(false);
            camera_2.SetActive(false);
            camera_3.SetActive(false);
            camera_4.SetActive(false);
        }
    }

    void DeActivatePlayers()
    {
        player_1.SetActive(false);
        player_2.SetActive(false);
        player_3.SetActive(false);
        player_4.SetActive(false);
    }

    void DeActivateCameras()
    {
        camera_1.SetActive(false);
        camera_2.SetActive(false);
        camera_3.SetActive(false);
        camera_4.SetActive(false);
    }

    void Pause()
    {
        if(Input.GetKey(KeyCode.Escape) && !paused)
        {
            paused = true;
            Time.timeScale = 0;
            DeActivateCameras();
            mainCamera.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.Escape) && paused)
        {
            paused = false;
            Time.timeScale = 1;
            ActivateCameras();
            mainCamera.SetActive(false);
        }
    }

    void FindPowerUpSpawnPoints()
    {
        foreach (var SpawnPoints in GameObject.FindGameObjectsWithTag("Power_Up_Spawn_Point"))
        {
            powerUpSpawnPoints.Add(SpawnPoints.transform.position);
        }
    }

    void SetPowerUps()
    {
        if(spawnTimer <= 0)
        {
            lastSpawnPoint = nextSpawnPoint;

            if (currentNrOfPowerUps <= maxPowerUps && nextSpawnPoint != lastSpawnPoint)
            {
                GameObject PowerUp = Instantiate(powerUp, nextSpawnPoint, Quaternion.identity) as GameObject;
                nextSpawnPoint = powerUpSpawnPoints[Random.Range(0, powerUpSpawnPoints.Count)];
                spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
            }
        }
        spawnTimer--;
    }

    
}

