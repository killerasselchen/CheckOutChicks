using UnityEngine;
using System.Collections;

public class Option : Menu 
{
    public MainMenu Menu;

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(Menu);
    }
}
