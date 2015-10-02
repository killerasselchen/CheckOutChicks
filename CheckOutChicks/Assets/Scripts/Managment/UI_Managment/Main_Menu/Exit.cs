//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;


public class Exit : Menu
{
    public Button startButton;

    public MainMenu MainMenu;
    public UglyPotatoesOutroMenu UglyPotatoesOutroMenu;

    public void Start()
    {
        startButton.Select();
    }
    public void BackToMainMenu()
    {
        GameManager.OpenMenu(MainMenu);
    }

    public void ExitGame()
    {
        UglyPotatoesOutroMenu instance = (UglyPotatoesOutroMenu)GameManager.OpenMenu(UglyPotatoesOutroMenu);
    }
}