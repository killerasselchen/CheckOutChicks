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

    //To set the Playerquantity
    public static bool setToSinglePlayer;
    public static bool setToTwoPlayers;
    public static bool setToThreePlayers;
    public static bool setToFourPlayers;
    private int playerQuantity;

    private bool paused = true;

    public static List<GameObject> activeCameras;
    public static GameObject camera_1;
    public static GameObject camera_2;
    public static GameObject camera_3;
    public static GameObject camera_4;
    private GameObject mainCamera;

    public static List<GameObject> activePlayers;
    public static GameObject player_1;
    public static GameObject player_2;
    public static GameObject player_3;
    public static GameObject player_4;
    //public static List<GameObject> playerList;

    //public GameObject powerUp;
    public int maxMapPowerUps = 6;
    public static int currentMapPowerUps;
    private int nextPowerUp;
    private float Power_Up_Spawn_Timer = 5;
    private float minSpawnDelay = 1;
    private float maxSpawnDelay = 4;
    private GameObject[] powerUpSpawnPoints;
    private bool nextSpawnPointCheck;
    //public static List<Power_Up> availablePowerUps;
    public static Power_Up[] availablePowerUps = new Power_Up[2];
    public static GameObject stickyPuddlePrefab;
    
    //Buyable Items
    //private GameObject[] itemSpawnPoints;
    private List<GameObject> itemSpawnPoints;
    //private float Item_Spawn_Timer = 5;
    private int nextItem;

    
    void FindItemSpawnPoints()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Product").Length; i++)
		{
            itemSpawnPoints.Add(GameObject.FindGameObjectsWithTag("Product")[i]);
		}

        for (int i = 0; i < itemSpawnPoints.Count; i++)
        {
            itemSpawnPoints[i].SetActive(false);
        }
    }

    void Awake ()
    {
        FindPlayers();
        FindCameras();
        FindPowerUpSpawnPoints();
        SetAvailablePowerUps();
        FindItemSpawnPoints();
        Time.timeScale = 0;

        //When Load Level
        //powerUps = new GameObject[GameObject.FindGameObjectsWithTag("Power_up").Length];
    }

    void SpawnItems()
    {
        //if (currentMapPowerUps <= maxMapPowerUps)
        //{
        //    if (Item_Spawn_Timer <= 0)
        //    {
        //        nextSpawnPointCheck = true;
        //        while (nextSpawnPointCheck == true)
        //        {
        //            nextPowerUp = Random.Range(0, powerUpSpawnPoints.Length);

        //            if (!powerUpSpawnPoints[nextPowerUp].activeInHierarchy)
        //            {
        //                powerUpSpawnPoints[nextPowerUp].SetActive(true);
        //                nextSpawnPointCheck = false;
        //                currentMapPowerUps++;
        //            }
        //            Item_Spawn_Timer = Random.Range(minSpawnDelay, maxSpawnDelay);
        //        }
        //    }
        //    Item_Spawn_Timer -= 1 * Time.deltaTime;
        //}
    }

    void SelectNextItem()
    {
        nextItem = Random.Range(0, itemSpawnPoints.Count);


        //if()
    }
	
	void Update () 
    {
        KeyControl();
        SpawnPowerUp();
	}

    void FixedUpdate()
    {

    }

    void KeyControl()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.F1) && paused)
        {
            setToSinglePlayer = true;
            PlayerQuantitySelection();
        }
        else if (Input.GetKeyDown(KeyCode.F2) && paused)
        {
            setToTwoPlayers = true;
            PlayerQuantitySelection();
        }
        else if (Input.GetKeyDown(KeyCode.F3) && paused)
        {
            setToThreePlayers = true;
            PlayerQuantitySelection();
        }
        else if (Input.GetKeyDown(KeyCode.F4) && paused)
        {
            setToFourPlayers = true;
            PlayerQuantitySelection();
        }
    }

    //Little Function to test the PlayerQuantitySelection and the Activation of Players and Cameras. (4.6.2015)
    void PlayerQuantitySelection()
    {
        if (setToSinglePlayer == true)
        {
            StartGame();
        }
        else if (setToTwoPlayers == true)
        {
            StartGame();
        }
        else if (setToThreePlayers == true)
        {
            StartGame();
        }
        else if (setToFourPlayers == true)
        {
            StartGame();
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
        if(!paused)
        {
            paused = true;
            Time.timeScale = 0;
            DeActivateCameras();
            mainCamera.SetActive(true);
        }
        else if(paused)
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
            if(Power_Up_Spawn_Timer <= 0)
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
                    Power_Up_Spawn_Timer = Random.Range(minSpawnDelay, maxSpawnDelay);
                }
            }
            Power_Up_Spawn_Timer -= 1 * Time.deltaTime;
        }
    }

    void SetAvailablePowerUps()
    {
        //This tim HardCoding !! Must fix
        //availablePowerUps.Add(new Confuse_Other());
        //availablePowerUps.Add(new Sticky_Puddle());
        //powerUps.Add
        availablePowerUps[0] = new Confuse_Other();
        availablePowerUps[1] = new Sticky_Puddle();
    }

    void SetActivePlayerList()
    {
        playerQuantity = GameObject.FindGameObjectsWithTag("Player").Length;

        for (int i = 1; i < playerQuantity + 1; i++)
        {
            activePlayers.Add(GameObject.FindGameObjectWithTag("P_" + i));
        }
    }

    void SetActiveCameraList()
    {
        for (int i = 1; i < playerQuantity + 1; i++)
        {
            activeCameras.Add(GameObject.FindGameObjectWithTag("Camera_" + i));
        }
    }

    void StartGame()
    {
        Debug.Log("startgame");

        ActivatePlayers();
        ActivateCameras();
        paused = false;
        Time.timeScale = 1;
        SetActivePlayerList();
        SetActiveCameraList();
    }


    //PowerUp Managment
    void LayStickyPuddle()
    {

    }
}

