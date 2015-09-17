using UnityEngine;
using System.Collections;

public class InGame : Menu
{
    public PauseMenu pauseMenu;

    public void Awake()
    {
        Time.timeScale = 1;
    }

	void Update ()
    {
	    if(Input.GetKeyDown("Pause"))
        {
            PauseMenu instance = (PauseMenu)GameManager.OpenMenu(pauseMenu);
        }
	}
}
