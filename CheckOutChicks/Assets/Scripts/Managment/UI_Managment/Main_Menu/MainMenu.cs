using UnityEngine;
using System.Collections;

public class MainMenu : Menu
{
    public Credits CreditsMenu;
    public Play PlayMenu;
    public Exit ExitMenu;
    public Option OptionMenux;
    public Manuals ManualsMenu;
    

    public void OpenCredits()
    {
        Credits instance = (Credits)GameManager.OpenMenu(CreditsMenu);
    }

    public void OpenPlayersMenu()
    {
        Play instance = (Play)GameManager.OpenMenu(PlayMenu);
    }

    public void OpenManualsMenu()
    {
        Manuals instance = (Manuals)GameManager.OpenMenu(ManualsMenu);
    }

    public void OpenOptionMenu()
    {
        Option instance = (Option)GameManager.OpenMenu(OptionMenux);
    }

    public void OpenExitMenu()
    {
        Exit instance = (Exit)GameManager.OpenMenu(ExitMenu);
    }

    public void Close()
    {
        Application.Quit();
    }
	
}
