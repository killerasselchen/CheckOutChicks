using UnityEngine;
using System.Collections;

public class CreditsMenu : Menu
{
    public MainMenu Menu;

    private void Start()
    {
        
    }

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(Menu);
    }
}
