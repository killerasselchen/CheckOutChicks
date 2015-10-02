﻿//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using System.Collections.Generic;
using UnityEngine;

public enum PlayerName { One, Two, Three, Four }

public enum PlayMode { Single = 1, Two = 2, Three = 3, Four = 4 }

public class GameManager : MonoBehaviour
{
    #region Music

    [SerializeField]
    private GameObject inGameMusic;

    [SerializeField]
    private GameObject menuMusic;

    #endregion Music

    #region Menu UI

    public Menu CurrentMenu;
    public EndMenu EndMenu;
    public Menu InitialMenu;
    public PauseMenu PauseMenu;
    private Player winner;

    public void CheckInput()
    {
        if (Input.GetButton("Pause"))
        {
            Time.timeScale = 0;
            PauseMenu instance = (PauseMenu)OpenMenu(PauseMenu);
        }
    }

    public void CloseMenu()
    {
        if (CurrentMenu)
            Destroy(CurrentMenu.gameObject);
        menuMusic.SetActive(false);
        inGameMusic.SetActive(true);
    }

    public TMenu OpenMenu<TMenu>(TMenu view) where TMenu : Menu
    {
        if (CurrentMenu)
            Destroy(CurrentMenu.gameObject);
        TMenu instance = Instantiate(view);
        instance.GameManager = this;
        CurrentMenu = instance;
        inGameMusic.SetActive(false);
        menuMusic.SetActive(true);
        return instance;
    }

    public void SetWinner()
    {
        float winnerPoints = 0;

        foreach (var player in activePlayers)
        {

            if (player.gameObject.GetComponent<Player>().MyPoints >= winnerPoints)
            {
                winnerPoints = player.gameObject.GetComponent<Player>().MyPoints;
                winner = player.gameObject.GetComponent<Player>();
                Debug.Log("winner: " + winner.name);
                Debug.Log("winner points: " + winnerPoints);

            }
        }
        winner.MakeMeToWinner();
    }

    #endregion Menu UI

    #region Player Cameras

    public static List<Camera> activeCameras = new List<Camera>();

    public static Rect[][] viewports =
    {
        new Rect[] {new Rect (0,0,1,1)},
        new Rect[] {new Rect (0,0.5f,1,0.5f),new Rect(0,0,1,0.5f)},
        new Rect[] {new Rect (0,0.5f,0.5f,0.5f),new Rect(0.5f,0.5f,0.5f,0.5f),new Rect(0,0,0.5f,0.5f)},
        new Rect[] {new Rect (0,0.5f,0.5f,0.5f),new Rect(0.5f,0.5f,0.5f,0.5f),new Rect(0,0,0.5f,0.5f),new Rect(0.5f,0,0.5f,0.5f)}
    };

    [SerializeField]
    private Camera playerCameraPrefab;

    private void SetLayerRecursive(GameObject gameObject, int layer)
    {
        gameObject.layer = layer;

        foreach (Transform child in gameObject.transform)
        {
            SetLayerRecursive(child.gameObject, layer);
        }
    }

    #endregion Player Cameras

    #region Market Cameras

    public bool inMainMenu = true;

    private Camera[] cameras;

    private Camera marketOneFirstCam;

    [SerializeField]
    private Camera marketOneFirstCamPrefab;

    private Camera marketOneSecCam;

    [SerializeField]
    private Camera marketOneSecCamPrefab;

    private Camera marketTwoFirstCam;

    [SerializeField]
    private Camera marketTwoFirstCamPrefab;

    private Camera marketTwoSecCam;

    [SerializeField]
    private Camera marketTwoSecCamPrefab;

    [SerializeField]
    private Sprite startMenuBackground;

    //um den zugriff für das Pause Menü und seinen Button "ToMainMenu" zu ermöglichen
    //public void ActivateMarketCams()
    //{
    //    if (marketOneIsActive)
    //    {
    //        marketOneFirstCam.gameObject.SetActive(true);
    //        marketOneSecCam.gameObject.SetActive(true);
    //    }
    //    else if (marketTwoIsActive)
    //    {
    //        marketTwoFirstCam.gameObject.SetActive(true);
    //        marketTwoSecCam.gameObject.SetActive(true);
    //    }
    //}

    public void SetRectsOfMarketCams()
    {
        if (marketOneIsActive)
        {
            if (inMainMenu)
            {
                marketOneFirstCam.rect = new Rect(0, 0.5f, 0.4f, 0.4f);
                marketOneSecCam.rect = new Rect(0, 0.1f, 0.4f, 0.4f);
            }
            else
            {
                marketOneFirstCam.rect = new Rect(0.1f, 0.55f, 0.4f, 0.4f);
                marketOneSecCam.rect = new Rect(0.5f, 0.55f, 0.4f, 0.4f);
            }
        }
        else if (marketTwoIsActive)
        {
            if (inMainMenu)
            {
                marketTwoFirstCam.rect = new Rect(0, 0.5f, 0.4f, 0.4f);
                marketTwoSecCam.rect = new Rect(0, 0.1f, 0.4f, 0.4f);
            }
            else
            {
                marketTwoFirstCam.rect = new Rect(0.1f, 0.55f, 0.4f, 0.4f);
                marketTwoSecCam.rect = new Rect(0.5f, 0.55f, 0.4f, 0.4f);
            }
        }
    }

    private void DeactivateMarketCams()
    {
        if (marketOneIsActive)
        {
            marketOneFirstCam.gameObject.SetActive(false);
            marketOneSecCam.gameObject.SetActive(false);
        }
        else if (marketTwoIsActive)
        {
            marketTwoFirstCam.gameObject.SetActive(false);
            marketTwoSecCam.gameObject.SetActive(false);
        }
    }

    private void LoadMarketSecuireCams()
    {
        marketOneFirstCam = Instantiate(marketOneFirstCamPrefab, marketOneFirstCamPrefab.transform.position, marketOneFirstCamPrefab.transform.rotation) as Camera;
        marketOneSecCam = Instantiate(marketOneSecCamPrefab, marketOneSecCamPrefab.transform.position, marketOneSecCamPrefab.transform.rotation) as Camera;

        marketTwoFirstCam = Instantiate(marketTwoFirstCamPrefab, marketTwoFirstCamPrefab.transform.position, marketTwoFirstCamPrefab.transform.rotation) as Camera;
        marketTwoSecCam = Instantiate(marketTwoSecCamPrefab, marketTwoSecCamPrefab.transform.position, marketTwoSecCamPrefab.transform.rotation) as Camera;
    }

    #endregion Market Cameras

    #region Player

    public static List<GameObject> activePlayers = new List<GameObject>();
    public static List<Canvas> activePlayerUis = new List<Canvas>();

    private GameObject lastPlayerSpawnPoint;

    [SerializeField]
    private Player[] playerPrefabs;

    [SerializeField]
    private List<GameObject> playerSpawnPoints = new List<GameObject>();

    //private Player[] players;
    [SerializeField]
    private Canvas playerUIPrefab;

    private Canvas[] playerUIs;

    public void SetToFourPlayer()
    {
        selectedPlayMode = PlayMode.Four;
    }

    public void SetToSinglePlayer()
    {
        selectedPlayMode = PlayMode.Single;
    }

    public void SetToThreePlayer()
    {
        selectedPlayMode = PlayMode.Three;
    }

    public void SetToTwoPlayer()
    {
        selectedPlayMode = PlayMode.Two;
    }

    private void FindPlayerSpawnPoints()
    {
        playerSpawnPoints.Clear();

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Player_Spawn_Point");

        for (int i = 0; i < temp.Length; i++)
        {
            playerSpawnPoints.Add(temp[i]);
        }
    }

    private Vector3 SelectRandomPlayerSpawnPoint()
    {
        if (lastPlayerSpawnPoint != null)
            playerSpawnPoints.Remove(lastPlayerSpawnPoint);

        int temp = Random.Range(0, playerSpawnPoints.Count);
        lastPlayerSpawnPoint = playerSpawnPoints[temp];
        Vector3 tempVector = lastPlayerSpawnPoint.transform.position;
        return tempVector;
    }

    #endregion Player

    #region Markets

    [SerializeField]
    private GameObject MarketOne;

    [SerializeField]
    private bool marketOneIsActive;

    [SerializeField]
    private GameObject MarketTwo;

    [SerializeField]
    private bool marketTwoIsActive;

    public void SelectMarketOne()
    {
        MarketTwo.SetActive(false);
        MarketOne.SetActive(true);

        marketTwoFirstCam.gameObject.SetActive(false);
        marketTwoSecCam.gameObject.SetActive(false);

        marketOneFirstCam.gameObject.SetActive(true);
        marketOneSecCam.gameObject.SetActive(true);

        marketOneIsActive = true;
        marketTwoIsActive = false;
    }

    public void SelectMarketTwo()
    {
        MarketOne.SetActive(false);
        MarketTwo.SetActive(true);

        marketOneFirstCam.gameObject.SetActive(false);
        marketOneSecCam.gameObject.SetActive(false);

        marketTwoFirstCam.gameObject.SetActive(true);
        marketTwoSecCam.gameObject.SetActive(true);

        marketTwoIsActive = true;
        marketOneIsActive = false;
    }

    #endregion Markets

    [SerializeField]
    public static float gameTimer;

    [SerializeField]
    private PowerUpManager powerUpManager;

    private PlayMode selectedPlayMode;

    [SerializeField]
    private ShoppingManager shoppingManager;

    public void Update()
    {
        CheckInput();
    }
    
    public void FixedUpdate()
    {

        if (gameTimer >= 0)
            gameTimer -= 1 * Time.deltaTime;
        else if (gameTimer <= 0)
        {
            SetWinner();
            OpenMenu(EndMenu);
            Time.timeScale = 0;
        }
    }

    public void SetPlayMode(PlayMode playMode)
    {
        FindPlayerSpawnPoints();
        this.gameObject.GetComponent<PowerUpManager>().FindPowerUpSpawnPoints();

        playerUIs = new Canvas[(int)playMode];
        cameras = new Camera[(int)playMode];

        for (int i = 0; i < (int)playMode; i++)
        {
            Player player = Instantiate(playerPrefabs[i]);
            player.transform.position = SelectRandomPlayerSpawnPoint();
            player.GetComponent<Move>().playerTag = player.tag;
            player.Shopping_Manager = shoppingManager;
            player.Power_Up_Manager = powerUpManager;
            Camera playerCamera = Instantiate(playerCameraPrefab);
            activeCameras.Add(playerCamera);
            SetLayerRecursive(playerCamera.gameObject, i + 9);
            playerCamera.cullingMask += 1 << (i + 9);
            playerCamera.rect = viewports[(int)playMode - 1][i];
            CameraMovements cameraMovment = playerCamera.GetComponent<CameraMovements>();
            cameraMovment.player_Position = player.transform;
            cameraMovment.camOrigin = player.CameraPosition;
            cameraMovment.camTarget = player.CameraTarget;
            Canvas playerUI = Instantiate(playerUIPrefab);
            activePlayerUis.Add(playerUI);
            SetLayerRecursive(playerUI.gameObject, i + 9);
            playerUI.worldCamera = playerCamera;
            player.Ui_Power_Up = playerUI.GetComponent<PowerUpUI>();
            player.Ui_Points = player.Ui_Power_Up.PointsText;
            activePlayers.Add(player.gameObject);
        }
    }

    public void StartGame()
    {
        CloseMenu();
        activePlayers.Clear();
        activeCameras.Clear();
        activePlayerUis.Clear();
        DeactivateMarketCams();
        shoppingManager.Initialize();
        SetPlayMode(selectedPlayMode);
        gameTimer = 300;
        Time.timeScale = 1;
    }

    private void Awake()
    {
        LoadMarketSecuireCams();
        SelectMarketOne();
    }

    private void Start()
    {
        OpenMenu(InitialMenu);
    }
}