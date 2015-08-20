//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //dont destroy on load
    //OnLevelWasLoaded

    //To set the Playerquantity
    public bool setToSinglePlayer;

    public bool setToTwoPlayers;
    public bool setToThreePlayers;
    public bool setToFourPlayers;
    private int playerQuantity;

    private bool paused = true;

    public static List<GameObject> activeCameras = new List<GameObject>();
    public static GameObject camera_1;
    public static GameObject camera_2;
    public static GameObject camera_3;
    public static GameObject camera_4;
    private GameObject mainCamera;

    public static List<GameObject> activePlayers = new List<GameObject>();
    public static GameObject player_1;
    public static GameObject player_2;
    public static GameObject player_3;
    public static GameObject player_4;
    //public static List<GameObject> playerList;

    ////Challenges. Derzeit noch NiceToHave
    //höhste Geschwindigkeit
    //meisten Einkäufe
    //längste Fahrtstrecke
    //meisten PowerUps

    private void Awake()
    {
        FindPlayers();
        FindCameras();
        Time.timeScale = 0;
    }

    private void Update()
    {
        KeyControl();
    }

    private void KeyControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && paused)
        {
            setToSinglePlayer = true;
            PlayerQuantitySelection();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && paused)
        {
            setToTwoPlayers = true;
            PlayerQuantitySelection();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && paused)
        {
            setToThreePlayers = true;
            PlayerQuantitySelection();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && paused)
        {
            setToFourPlayers = true;
            PlayerQuantitySelection();
        }
    }

    //Little Function to test the PlayerQuantitySelection and the Activation of Players and Cameras. (4.6.2015)
    private void PlayerQuantitySelection()
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
    private void FindPlayers()
    {
        player_1 = GameObject.FindGameObjectWithTag("P_1");
        player_2 = GameObject.FindGameObjectWithTag("P_2");
        player_3 = GameObject.FindGameObjectWithTag("P_3");
        player_4 = GameObject.FindGameObjectWithTag("P_4");

        DeActivatePlayers();
    }

    //Find over Tags the Camera GameObjects. It is outside the "FindPlayer()", because i wana use it later for more Cameras an nother funktions. (5.6.2015)
    //Only active Objects will be find over Tag. I look for a work around, but yet i search all GameObjects and deactivate them.
    private void FindCameras()
    {
        mainCamera = GameObject.FindGameObjectWithTag("Main_Camera");
        camera_1 = GameObject.FindGameObjectWithTag("Camera_1");
        camera_2 = GameObject.FindGameObjectWithTag("Camera_2");
        camera_3 = GameObject.FindGameObjectWithTag("Camera_3");
        camera_4 = GameObject.FindGameObjectWithTag("Camera_4");

        DeActivateCameras();
    }

    //Activate the Player GameObjects. This way i can check over an nother bool if a Controller ist conected (5.6.2015)
    private void ActivatePlayers()
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
    private void ActivateCameras()
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

    private void DeActivatePlayers()
    {
        player_1.SetActive(false);
        player_2.SetActive(false);
        player_3.SetActive(false);
        player_4.SetActive(false);
    }

    private void DeActivateCameras()
    {
        camera_1.SetActive(false);
        camera_2.SetActive(false);
        camera_3.SetActive(false);
        camera_4.SetActive(false);
    }

    private void Pause()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            DeActivateCameras();
            mainCamera.SetActive(true);
        }
        else if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            ActivateCameras();
            mainCamera.SetActive(false);
        }
    }

    private void SetActivePlayerList()
    {
        playerQuantity = GameObject.FindGameObjectsWithTag("Player").Length;

        for (int i = 1; i < playerQuantity + 1; i++)
        {
            activePlayers.Add(GameObject.FindGameObjectWithTag("P_" + i));
        }
    }

    private void SetActiveCameraList()
    {
        for (int i = 1; i < playerQuantity + 1; i++)
        {
            activeCameras.Add(GameObject.FindGameObjectWithTag("Camera_" + i));
        }
    }

    public void StartGame()
    {
        ActivatePlayers();
        ActivateCameras();
        paused = false;
        Time.timeScale = 1;
        SetActivePlayerList();
        SetActiveCameraList();
    }

    public void SetToTwoPlayer()
    {
        setToTwoPlayers = true;
    }

    public void SetToThreePlayer()
    {
        setToThreePlayers = true;
    }

    public void SetToFourPlayer()
    {
        setToFourPlayers = true;
    }

    public void ExitGame()
    {
        //if Sure .... than go
        Application.CancelQuit();
        Debug.Log("exit");
    }
}