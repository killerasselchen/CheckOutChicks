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
    public static int playerQuantity;

    private bool paused = true;

    public static GameObject[] cameras;
    public static GameObject camera_1;
    public static GameObject camera_2;
    public static GameObject camera_3;
    public static GameObject camera_4;
    private GameObject mainCamera;

    public static GameObject[] activePlayers;
    public static GameObject player_1;
    public static GameObject player_2;
    public static GameObject player_3;
    public static GameObject player_4;
    //public static List<GameObject> playerList;

    //public GameObject powerUp;
    public int maxMapPowerUps = 6;
    public static int currentMapPowerUps;
    private int nextPowerUp;
    private float spawnTimer;
    private float minSpawnDelay = 1;
    private float maxSpawnDelay = 4;
    private GameObject[] powerUpSpawnPoints;
    private bool nextSpawnPointCheck;
    public static GameObject[] powerUps;
    
    
    void Awake ()
    {
        FindPlayers();
        FindCameras();
        FindPowerUpSpawnPoints();
        FindAvadeblePowerUps();
        Time.timeScale = 0;

        //When Load Level
        //powerUps = new GameObject[GameObject.FindGameObjectsWithTag("Power_up").Length];
    }
	
	void Update () 
    {
        KeyControl();
        PlayerQuantitySelection();
        SpawnPowerUp();
	}

    void FixedUpdate()
    {
        Pause();
    }

    void LateUpdate()
    {

    }
    void KeyControl()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            setToSinglePlayer = true;
        }
        else if (Input.GetKey(KeyCode.F2))
        {
            setToTwoPlayers = true;
        }
        else if (Input.GetKey(KeyCode.F3))
        {
            setToThreePlayers = true;
        }
        else if (Input.GetKey(KeyCode.F4))
        {
            setToFourPlayers = true;
        }
    }

    //Little Function to test the PlayerQuantitySelection and the Activation of Players and Cameras. (4.6.2015)
    void PlayerQuantitySelection()
    {
        if (setToSinglePlayer == true)
        {
            StartGame();
            //ActivatePlayers();
            //ActivateCameras();
            //paused = false;
            //Time.timeScale = 1;
        }
        else if (setToTwoPlayers == true)
        {
            StartGame();
            //ActivatePlayers();
            //ActivateCameras();
            //paused = false;
            //Time.timeScale = 1;
        }
        else if (setToThreePlayers == true)
        {
            StartGame();
            //ActivatePlayers();
            //ActivateCameras();
            //paused = false;
            //Time.timeScale = 1;
        }
        else if (setToFourPlayers = true)
        {
            StartGame();
            //ActivatePlayers();
            //ActivateCameras();
            //paused = false;
            //Time.timeScale = 1;
        }
        playerQuantity = GameObject.FindGameObjectsWithTag("Player").Length;

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
        powerUpSpawnPoints = GameObject.FindGameObjectsWithTag("Power_Up"); //_Spawn_Point for later

        for (int i = 0; i < powerUpSpawnPoints.Length; i++)
        {
            powerUpSpawnPoints[i].SetActive(false);
        }
    }

    void SpawnPowerUp()
    {
        if(currentMapPowerUps <= maxMapPowerUps)
        {
            if(spawnTimer <= 0)
            {
                nextSpawnPointCheck = true;
                while (nextSpawnPointCheck == true)
                {
                    nextPowerUp = Random.Range(0, powerUpSpawnPoints.Length);

                    if (!powerUpSpawnPoints[nextPowerUp].activeInHierarchy)
                    {
                        powerUpSpawnPoints[nextPowerUp].SetActive(true);
                        nextSpawnPointCheck = false;
                        currentMapPowerUps++;
                    }
                    spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
                }
            }
            spawnTimer -= 1 * Time.deltaTime;
        }
    }

    void FindAvadeblePowerUps()
    {
        powerUps = GameObject.FindGameObjectsWithTag("PU"); //"Power_Up" later

        //for (int i = 0; i < powerUps.Length; i++)
        //{
        //    powerUps[i].SetActive(false);
        //}
    }

    void SetActivePlayerList()
    {
        int playerQuantity = GameObject.FindGameObjectsWithTag("Player").Length;

        for (int i = 0; i < playerQuantity; i++)
			{
                activePlayers[i] = GameObject.FindGameObjectWithTag("P_" + i);
			}
    }

    void SetActiveCameraList()
    {
        for (int i = 0; i < playerQuantity; i++)
        {
            cameras[i] = GameObject.FindGameObjectWithTag("Camera_" + i);
        }
    }

    void StartGame()
    {
        ActivatePlayers();
        ActivateCameras();
        paused = false;
        Time.timeScale = 1;
        SetActivePlayerList();
        SetActiveCameraList();
    }
}

