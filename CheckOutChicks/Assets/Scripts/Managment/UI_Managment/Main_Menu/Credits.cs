using UnityEngine;
using System.Collections;

public class Credits : Menu
{
    public MainMenu MainMenu;

    
    public void BackToMainMenu()
    {
        GameManager.OpenMenu(MainMenu);
    }
}
