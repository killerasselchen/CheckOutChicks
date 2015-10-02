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
        timer = 80;
    }

    void Update()
    {
        if (timer <= 0)
            SwitchToNextScreen();

        timer -= 1;
    }

    private void SwitchToNextScreen()
    {
        LeaveMenu instance = (LeaveMenu)GameManager.OpenMenu(LeaveMenu);
    }
}