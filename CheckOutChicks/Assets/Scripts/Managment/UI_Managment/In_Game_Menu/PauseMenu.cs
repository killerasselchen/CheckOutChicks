//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : Menu
{
    public MainMenu MainMenu;
    public Button StartButton;

    //[SerializeField]
    //private GameManager gameManager;

    public void Start()
    {
        StartButton.Select();
    }

    public void Awake()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        this.GameManager.CloseMenu();
    }

    public void OpenMainMenu()
    {
        //gameManager.RestartMainMenu();
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            ContinueGame();
        }
    }
}