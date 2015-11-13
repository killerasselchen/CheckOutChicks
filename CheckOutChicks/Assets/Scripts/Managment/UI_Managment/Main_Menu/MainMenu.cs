//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    public Credits CreditsMenu;
    public Exit ExitMenu;
    public Manuals ManualsMenu;
    public Option OptionMenux;
    public Play PlayMenu;
    public Button startButton;
    public StoryMenu StoryMenu;

    public void OpenCredits()
    {
        Credits instance = (Credits)GameManager.OpenMenu(CreditsMenu);
    }

    public void OpenExitMenu()
    {
        Exit instance = (Exit)GameManager.OpenMenu(ExitMenu);
    }

    public void OpenManualsMenu()
    {
        Manuals instance = (Manuals)GameManager.OpenMenu(ManualsMenu);
    }

    public void OpenOptionMenu()
    {
        Option instance = (Option)GameManager.OpenMenu(OptionMenux);
    }

    public void OpenPlayersMenu()
    {
        GameManager.inMainMenu = false;
        Play instance = (Play)GameManager.OpenMenu(PlayMenu);
    }

    public void OpenStoryMenu()
    {
        StoryMenu instance = (StoryMenu)GameManager.OpenMenu(StoryMenu);
    }

    public void Start()
    {
        startButton.Select();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton2))
            OpenExitMenu();
    }
}