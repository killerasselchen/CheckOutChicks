using UnityEngine;
using System.Collections;

public class Manuals : Menu 
{
    public MainMenu Menu;

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(Menu);
    }
	
}
