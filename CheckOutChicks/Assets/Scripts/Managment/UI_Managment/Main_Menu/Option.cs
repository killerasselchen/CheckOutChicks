using UnityEngine;
using System.Collections;

public class OptionMenu : Menu 
{
    public MainMenu Menu;



    public void BackToMainMenu()
    {
        GameManager.OpenMenu(Menu);
    }
}
