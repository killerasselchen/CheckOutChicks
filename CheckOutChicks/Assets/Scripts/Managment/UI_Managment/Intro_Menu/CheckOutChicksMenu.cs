//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015
using UnityEngine.UI;
using UnityEngine;

public class CheckOutChicksMenu : Menu
{
    public MainMenu MainMenu;

    private float timer;

    void Awake()
    {
        timer = 2;
    }

    void Update()
    {
        if (timer <= 0 || Input.anyKeyDown)
            SwitchToNextScreen();

        timer -= 1 * Time.unscaledDeltaTime;
    }

    private void SwitchToNextScreen()
    {
        MainMenu instance = (MainMenu)GameManager.OpenMenu(MainMenu);
        Time.timeScale = 0;
    }
}