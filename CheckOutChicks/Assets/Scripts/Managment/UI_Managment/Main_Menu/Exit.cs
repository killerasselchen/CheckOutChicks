//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;

public class Exit : Menu
{
    public MainMenu MainMenu;
    public Button startButton;
    public UglyPotatoesOutroMenu UglyPotatoesOutroMenu;

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(MainMenu);
    }

    public void ExitGame()
    {
        UglyPotatoesOutroMenu instance = (UglyPotatoesOutroMenu)GameManager.OpenMenu(UglyPotatoesOutroMenu);
    }

    public void Start()
    {
        startButton.Select();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton2))
            BackToMainMenu();
    }
}