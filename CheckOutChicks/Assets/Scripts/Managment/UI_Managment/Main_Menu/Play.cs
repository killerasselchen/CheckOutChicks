using UnityEngine;
using System.Collections;

public class Play : Menu
{
    public MainMenu MainMenu;
    public LevelMenu LevelMenu;

    public void SetToSinglePlayer()
    {
        GameManager.SetToSinglePlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }

    public void SetToTwoPlayer()
    {
        GameManager.SetToTwoPlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }

    public void SetToThreePlayer()
    {
        GameManager.SetToThreePlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }

    public void SetToFourPlayer()
    {
        GameManager.SetToFourPlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(MainMenu);
    }
}
