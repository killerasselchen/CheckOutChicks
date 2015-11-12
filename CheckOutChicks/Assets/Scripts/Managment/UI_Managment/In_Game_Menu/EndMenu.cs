//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;

public class EndMenu : Menu
{
    public Button StartMenu;

    //[SerializeField]
    //private GameManager gameManager;

    public void Start()
    {
        StartMenu.Select();
    }

    public void Update()
    {
        if (Input.anyKeyDown)
            BackToMainMenu();
    }

    public void BackToMainMenu()
    {
        //gameManager.RestartMainMenu();
        Application.LoadLevel(Application.loadedLevelName);
    }
}