//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //dont destroy on load
    //ich muß die gefundenen GameObjects aktivieren!!!!!

    public static bool SetToSinglePlayer;
    public static bool SetToTwoPlayers;
    public static bool SetToThreePlayers;
    public static bool SetToFourPlayers;

    //later Privat. Only for Tests public!
    public bool Paused = false;

    private GameObject camera_1;
    private GameObject camera_2;
    private GameObject camera_3;
    private GameObject camera_4;
    private GameObject mainCamera;

    private GameObject player_1;
    private GameObject player_2;
    private GameObject player_3;
    private GameObject player_4;
    
    void Awake ()
    {
        FindPlayers();
        FindCameras();
    }

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        //if "anyKey works like i hope, i must test when the Class works. (4.6.2015)
        if (Input.anyKeyDown)
        {
            Pause();
            PlayerQuantitySelection();
            Debug.Log("KeyHitInUpdate");
        }
	}

    void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            Pause();
            Debug.Log("KeyHitInFixedUpdate");
        }
    }

    //Little Function to test the PlayerQuantitySelection and the Activation of Players and Cameras. (4.6.2015)
    void PlayerQuantitySelection()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            SetToSinglePlayer = true;
            ActivatePlayers();
            ActivateCameras();
        }
        else if (Input.GetKey(KeyCode.F2))
        {
            SetToTwoPlayers = true;
            ActivatePlayers();
            ActivateCameras();
        }
        else if (Input.GetKey(KeyCode.F3))
        {
            SetToThreePlayers = true;
            ActivatePlayers();
            ActivateCameras();
        }
        else if (Input.GetKey(KeyCode.F4))
        {
            SetToFourPlayers = true;
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
        //}
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
        //DeActivatePlayers();

        if (SetToSinglePlayer)
        {
            player_1.SetActive(true);
        }
        else if (SetToTwoPlayers)
        {
            player_1.SetActive(true);
            player_2.SetActive(true);
        }
        else if (SetToThreePlayers)
        {
            player_1.SetActive(true);
            player_2.SetActive(true);
            player_3.SetActive(true);
        }
        else if (SetToFourPlayers)
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
        if (Paused == false)
        {
            //DeActivateCameras();

            if (SetToSinglePlayer)
            {
                camera_1.SetActive(true);
            }
            else if (SetToTwoPlayers)
            {
                camera_1.SetActive(true);
                camera_2.SetActive(true);
            }
            else if (SetToThreePlayers)
            {
                camera_1.SetActive(true);
                camera_2.SetActive(true);
                camera_3.SetActive(true);
            }
            else if (SetToFourPlayers)
            {
                camera_1.SetActive(true);
                camera_2.SetActive(true);
                camera_3.SetActive(true);
                camera_4.SetActive(true);
            }

            mainCamera.SetActive(false);
        }

        else if (Paused)
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
        if(Input.GetKey(KeyCode.Escape) && !Paused)
        {
            Paused = true;
            Time.timeScale = 0;
            DeActivateCameras();
            mainCamera.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.Escape) && Paused)
        {
            Paused = false;
            Time.timeScale = 1;
            ActivateCameras();
            mainCamera.SetActive(false);
        }
    }
}

