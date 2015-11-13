//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015
using UnityEngine.UI;
using UnityEngine;

public class UglyPotatoesOutroMenu : Menu 
{
    public LeaveMenu LeaveMenu;

    private float timer;

    void Awake()
    {
        timer = 1;
    }

    void Update()
    {
        if (timer <= 0 || Input.anyKeyDown)
            SwitchToNextScreen();

        timer -= 1 * Time.deltaTime;
    }

    private void SwitchToNextScreen()
    {
        LeaveMenu instance = (LeaveMenu)GameManager.OpenMenu(LeaveMenu);
    }
}