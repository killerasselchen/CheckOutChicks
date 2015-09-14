using UnityEngine;
using System.Collections;

public class MainMenu : Menu
{
    public CreditsMenu CreditsMenu;
    public PlayersMenu PlayersMenu;
    

    public void OpenCredits()
    {
        CreditsMenu instance = (CreditsMenu)GameManager.OpenMenu(CreditsMenu);
    }

    public void OpenPlayersMenu()
    {
        PlayersMenu instance = (PlayersMenu)GameManager.OpenMenu(PlayersMenu);
    }

    public void Close()
    {
        GameManager.CloseMenu();

    }
	
}
