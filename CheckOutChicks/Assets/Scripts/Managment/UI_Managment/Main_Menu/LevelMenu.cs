using UnityEngine;
using System.Collections;

public class LevelMenu : Menu
{
    public Play PlayMenu;

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

    public void BackToPlayersMenu()
    {
        Play instance = (Play)GameManager.OpenMenu(PlayMenu);
    }
	
}
