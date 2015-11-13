//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : Menu
{
    public Play PlayMenu;
    public Button StartButton;

    public void BackToPlayersMenu()
    {
        Play instance = (Play)GameManager.OpenMenu(PlayMenu);
    }

    public void Start()
    {
        StartButton.Select();
    }

    public void StartGameInMarketOne()
    {
        GameManager.SelectMarketOne();
        GameManager.StartGame();
    }

    public void StartGameInMarketTwo()
    {
        GameManager.SelectMarketTwo();
        GameManager.StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton2))
            BackToPlayersMenu();
    }
}