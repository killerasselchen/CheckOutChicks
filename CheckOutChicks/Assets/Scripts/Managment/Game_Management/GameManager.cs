//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using System.Collections.Generic;
using UnityEngine;

public enum PlayerName { One, Two, Three, Four }

public enum PlayMode { Single = 1, Two = 2, Three = 3, Four = 4 }

public class GameManager : MonoBehaviour
{
    public static Rect[][] viewports =
    {
        new Rect[] {new Rect (0,0,1,1)},
        new Rect[] {new Rect (0,0.5f,1,0.5f),new Rect(0,0,1,0.5f)},
        new Rect[] {new Rect (0,0.5f,0.5f,0.5f),new Rect(0.5f,0.5f,0.5f,0.5f),new Rect(0,0,0.5f,0.5f)},
        new Rect[] {new Rect (0,0.5f,0.5f,0.5f),new Rect(0.5f,0.5f,0.5f,0.5f),new Rect(0,0,0.5f,0.5f),new Rect(0.5f,0,0.5f,0.5f)}
    };

    [SerializeField]
    private Sprite startMenuBackground;
    [SerializeField]
    private Sprite startMenuBackgroundMarketOne;
    [SerializeField]
    private Sprite startMenuBackgroundMarketTwo;

    private Camera[] cameras;

    private bool paused = true;

    [SerializeField]
    private Camera playerCameraPrefab;

    [SerializeField]
    private Player playerPrefab;

    private Player[] players;

    [SerializeField]
    private Canvas playerUIPrefab;

    private Canvas[] playerUIs;

    [SerializeField]
    private PowerUpManager powerUpManager;

    [SerializeField]
    private ShoppingManager shoppingManager;

    private bool supermarketOneIsActive;

    private bool supermarketTwoIsActive;

    //TODO: Need to implement it
    public void ExitGame()
    {
        //if Sure .... than go
        Application.CancelQuit();
        Debug.Log("exit");
    }

    public void SelectMarketOne()
    {
        supermarketOne.SetActive(true);
        supermarketTwoMainCam.gameObject.SetActive(false);
        supermarketTwo.SetActive(false);
        supermarketOneMainCamPrefab.gameObject.SetActive(true);
        mainUI.GetComponent<Canvas>().worldCamera = supermarketOneMainCam;
        startMenuBackground = startMenuBackgroundMarketOne;

        supermarketOneIsActive = true;
        supermarketTwoIsActive = false;
    }

    public void SelectMarketTwo()
    {
        //TODO: MainOne doesnt go out. And startSprite do not change
        supermarketTwo.SetActive(true);
        supermarketOneMainCamPrefab.gameObject.SetActive(false);
        supermarketOne.SetActive(false);
        supermarketTwoMainCam.gameObject.SetActive(true);
        mainUI.GetComponent<Canvas>().worldCamera = supermarketTwoMainCam;
        startMenuBackground = startMenuBackgroundMarketTwo;

        supermarketTwoIsActive = true;
        supermarketOneIsActive = false;
    }

    public void SetPlayMode(PlayMode playMode)
    {
        FindPlayerSpawnPoints();

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
        PreLoadSupermarkets();
        this.gameObject.GetComponent<PowerUpManager>().FindPowerUpSpawnPoints();
        //FindCameras();
        SelectMarketOne();
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

    private void PreLoadSupermarkets()
    {
        supermarketOne = Instantiate(supermarketOnePrefab) as GameObject;
        supermarketOneMainCam = Instantiate(supermarketOneMainCamPrefab,supermarketOneMainCamPrefab.transform.position, supermarketOneMainCamPrefab.transform.rotation) as Camera;

        supermarketTwo = Instantiate(supermarketTwoPrefab) as GameObject;
        supermarketTwoMainCam = Instantiate(supermarketTwoMainCamPrefab) as Camera;
    }

    //private void PrepairMainMenu()
    //{
    //    //GameObject MainMenu = Instantiate(mainUI) as GameObject;
    //    //GameObject PlayMenu = Instantiate(playMenu) as GameObject;
    //    //GameObject OptionMenu = Instantiate(optionMenu) as GameObject;
    //    //GameObject CreditsMenu = Instantiate(creditsMenu) as GameObject;
    //    //GameObject QuitMenu = Instantiate(quitMenu) as GameObject;
    //}
    private Vector3 SelectRandomPlayerSpawnPoint()
    {
        if (lastPlayerSpawnPoint != null)
            playerSpawnPoints.Remove(lastPlayerSpawnPoint);

        int temp = Random.Range(0, playerSpawnPoints.Count);
        lastPlayerSpawnPoint = playerSpawnPoints[temp];
        Vector3 tempVector = lastPlayerSpawnPoint.transform.position;
        return tempVector;
    }

    private void SetLayerRecursive(GameObject gameObject, int layer)
    {
        gameObject.layer = layer;

        foreach (Transform child in gameObject.transform)
        {
            SetLayerRecursive(child.gameObject, layer);
        }
    }

    #region InGame GameObjects

    public static List<Camera> activeCameras = new List<Camera>();

    public static List<GameObject> activePlayers = new List<GameObject>();

    #endregion InGame GameObjects

    #region Menu GameObjects

    [SerializeField]
    private GameObject creditsMenu;

    [SerializeField]
    private GameObject levelMenu;

    [SerializeField]
    private GameObject mainUI;

    [SerializeField]
    private GameObject optionMenu;

    [SerializeField]
    private GameObject playerMenu;

    [SerializeField]
    private GameObject quitMenu;

    #endregion Menu GameObjects

    #region Market GameObjects

    private GameObject lastPlayerSpawnPoint;

    [SerializeField]
    private List<GameObject> playerSpawnPoints = new List<GameObject>();

    private PlayMode selectedPlayMode;

    private GameObject supermarketOne;

    private Camera supermarketOneMainCam;

    [SerializeField]
    private Camera supermarketOneMainCamPrefab;

    [SerializeField]
    private GameObject supermarketOnePrefab;

    private GameObject supermarketTwo;

    private Camera supermarketTwoMainCam;

    [SerializeField]
    private Camera supermarketTwoMainCamPrefab;

    [SerializeField]
    private GameObject supermarketTwoPrefab;

    #endregion Market GameObjects

    ////Challenges. Derzeit noch NiceToHave
    //höhste Geschwindigkeit
    //meisten Einkäufe
    //längste Fahrtstrecke
    //meisten PowerUps

    #region Player Cameras

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

    //private void CreatePlayerCamera(Camera PlayerCamPrefab, Vector3 PlayerPosition)
    //{
    //    Camera PlayerCamera = Instantiate(PlayerCamPrefab, PlayerPosition, Quaternion.identity) as Camera;
    //    activeCameras.Add(PlayerCamera);
    //}

    #endregion Player Cameras

    //private void PlayMenu()
    //{
    //}

    //private void OptionMenu()
    //{
    //}

    //private void CreditMenu()
    //{
    //}

    //private void ExitMenu()
    //{
    //}
}