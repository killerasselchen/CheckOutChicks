using UnityEngine;
using System.Collections;

public class Exit : Menu 
{
    public MainMenu MainMenu;

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(MainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
}
