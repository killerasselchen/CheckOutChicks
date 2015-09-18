//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;

public class EndMenu : Menu
{
    public MainMenu mainMenu;
    public Button startButton;

    public void Awake()
    {
        Time.timeScale = 0;
        //this.gameObject.GetComponentInChildren<
    }
    public void Start()
    {
        startButton.Select();
    }
    public void OpenMainMenu()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}