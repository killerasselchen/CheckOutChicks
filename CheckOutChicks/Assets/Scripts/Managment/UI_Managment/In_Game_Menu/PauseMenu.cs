using UnityEngine;
using System.Collections;

public class PauseMenu : Menu
{
    public MainMenu mainMenu;

    public void Awake()
    {
        Time.timeScale = 0;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 1;
            this.GameManager.CloseMenu();
        }
    }

    public void OpenMainMenu()
    {
        MainMenu instance = (MainMenu)GameManager.OpenMenu(mainMenu);

    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        this.GameManager.CloseMenu();
    }
}
