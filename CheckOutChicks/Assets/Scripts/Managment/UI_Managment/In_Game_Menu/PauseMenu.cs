//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : Menu
{
    public MainMenu mainMenu;
    public Button startButton;
    public void Start()
    {
        startButton.Select();
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
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 1;
            this.GameManager.CloseMenu();
        }
    }
}