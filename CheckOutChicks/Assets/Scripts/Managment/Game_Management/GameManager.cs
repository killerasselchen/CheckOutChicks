//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerName { One, Two, Three, Four }

public enum PlayMode { Single = 1, Two = 2, Three = 3, Four = 4 }

public class GameManager : MonoBehaviour
{
    #region Menu UI

    public Menu InitialMenu;
    public Menu CurrentMenu;

    public TMenu OpenMenu<TMenu>(TMenu view) where TMenu : Menu
    {
        if (CurrentMenu)
            Destroy(CurrentMenu.gameObject);
        TMenu instance = Instantiate(view);
        instance.GameManager = this;
        CurrentMenu = instance;
        return instance;
    }

    public void CloseMenu()
    {
        if (CurrentMenu)
            Destroy(CurrentMenu.gameObject);
    }

    private void Start()
    {
        OpenMenu(InitialMenu);
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

    private Camera[] cameras;

    [SerializeField]
    private Sprite startMenuBackground;

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

    private GameObject lastPlayerSpawnPoint;

    [SerializeField]
    private Player playerPrefab;

    private Player[] players;

    [SerializeField]
    private List<GameObject> playerSpawnPoints = new List<GameObject>();

    [SerializeField]
    private Canvas playerUIPrefab;

    private Canvas[] playerUIs;

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

    private bool marketOneIsActive;

    [SerializeField]
    private GameObject MarketTwo;

    private bool marketTwoIsActive;

    public void SelectMarketOne()
    {
        MarketTwo.SetActive(false);
        MarketOne.SetActive(true);

        marketTwoFirstCam.gameObject.SetActive(false);
        marketTwoSecCam.gameObject.SetActive(false);

        marketOneFirstCam.gameObject.SetActive(true);
        marketOneSecCam.gameObject.SetActive(true);

        //mainUI.GetComponent<Canvas>().worldCamera = marketOneFirstCam;

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

        //mainUI.GetComponent<Canvas>().worldCamera = marketTwoFirstCam;

        marketTwoIsActive = true;
        marketOneIsActive = false;
    }

    #endregion Markets

    private bool paused = true;

    [SerializeField]
    private PowerUpManager powerUpManager;

    private PlayMode selectedPlayMode;

    [SerializeField]
    private ShoppingManager shoppingManager;

    public void SetPlayMode(PlayMode playMode)
    {
        FindPlayerSpawnPoints();
        //TODO: Erstellen des Scripts PowerUpManager bei Spielstart und dann die Methode bei Awake ausführen.
        this.gameObject.GetComponent<PowerUpManager>().FindPowerUpSpawnPoints();

        playerUIs = new Canvas[(int)playMode];
        cameras = new Camera[(int)playMode];
        players = new Player[(int)playMode];

        for (int i = 0; i < (int)playMode; i++)
        {
            Player player = Instantiate(playerPrefab);
            player.transform.position = SelectRandomPlayerSpawnPoint();
            player.gameObject.tag = "Player_" + ((PlayerName)i).ToString();
            player.GetComponent<Move>().playerTag = player.tag;
            player.shopping_Manager = shoppingManager;
            player.power_Up_Manager = powerUpManager;
            Camera playerCamera = Instantiate(playerCameraPrefab);
            SetLayerRecursive(playerCamera.gameObject, i + 9);
            playerCamera.rect = viewports[(int)playMode - 1][i];
            CameraMovements cameraMovment = playerCamera.GetComponent<CameraMovements>();
            cameraMovment.player_Position = player.transform;
            cameraMovment.camOrigin = player.cameraPosition;
            cameraMovment.camTarget = player.cameraTarget;
            Canvas playerUI = Instantiate(playerUIPrefab);
            SetLayerRecursive(playerUI.gameObject, i + 9);
            playerUI.worldCamera = playerCamera;
            player.ui_Power_Up = playerUI.GetComponent<PowerUpUI>();
            player.ui_Points = player.ui_Power_Up.PointsText;

            activePlayers.Add(player.gameObject);
        }
    }

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

    public void StartGame()
    {
        SetPlayMode(selectedPlayMode);
        // Time.timeScale = 1;
    }

    private void Awake()
    {
        //Time.timeScale = 0;
        LoadMarketSecuireCams();
        SelectMarketOne();
    }

    #region Menu GameObjects

    //TODO:
    //private void PrepairMainMenu()
    //{
    //    //GameObject MainMenu = Instantiate(mainUI) as GameObject;
    //    //GameObject PlayMenu = Instantiate(playMenu) as GameObject;
    //    //GameObject OptionMenu = Instantiate(optionMenu) as GameObject;
    //    //GameObject CreditsMenu = Instantiate(creditsMenu) as GameObject;
    //    //GameObject QuitMenu = Instantiate(quitMenu) as GameObject;
    //}

    //[SerializeField]
    //private GameObject creditsMenu;

    //[SerializeField]
    //private GameObject levelMenu;

    //[SerializeField]
    //private GameObject mainUI;

    //[SerializeField]
    //private GameObject optionMenu;

    //[SerializeField]
    //private GameObject playerMenu;

    //[SerializeField]
    //private GameObject quitMenu;

    #endregion Menu GameObjects

    #region Other Funktions

    //TODO: Need to implement it
    //public void ExitGame()
    //{
    //    //if Sure .... than go
    //    Application.CancelQuit();
    //    Debug.Log("exit");
    //}

    //TODO:
    //private void Pause()
    //{
    //    if (!paused)
    //    {
    //        paused = true;
    //        Time.timeScale = 0;
    //        DeActivateCameras();
    //        mainCamera.SetActive(true);
    //    }
    //    else if (paused)
    //    {
    //        paused = false;
    //        Time.timeScale = 1;
    //        ActivateCameras();
    //        mainCamera.SetActive(false);
    //    }
    //}

    //private void ActivatePlayerCameras()
    //{
    //    //Kurze Version für später wenn ich nur die Cams habe die auch nötig sind. Dazu fehlt mit die zuweisung der UI.canvas.renderCam und die UI.OnClick zuweisungen über Code
    //    foreach (var camera in activeCameras)
    //    {
    //        camera.gameObject.SetActive(true);
    //    }
    //    supermarketOneMainCam.gameObject.SetActive(false);
    //    supermarketTwoMainCam.gameObject.SetActive(false);

    //    //SetViewPorts();

    //}

    //private void DeactivatePlayerCameras()
    //{
    //    foreach (var camera in activeCameras)
    //    {
    //        camera.gameObject.SetActive(false);
    //    }

    //    if (supermarketOneIsActive)
    //        supermarketOneMainCam.gameObject.SetActive(true);
    //    else if (supermarketTwoIsActive)
    //        supermarketTwoMainCam.gameObject.SetActive(true);
    //}

    ////Challenges. Derzeit noch NiceToHave
    //höhste Geschwindigkeit(script gibt es schon, aber einbindung sieht mist aus, könnte aber ohne einblendung für ein Achivment genutzt werden)
    //TODO: meisten Einkäufe(Liste wird beim Einkauf geführt, aber noch nicht weiterverwendet) Zumindest die Punkte müssen ausgewertet werden
    //längste Fahrtstrecke
    //meisten PowerUps

    #endregion Other Funktions
}