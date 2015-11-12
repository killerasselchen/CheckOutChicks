//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015
using UnityEngine.UI;
using UnityEngine;

public class LeaveMenu : Menu 
{
    private float timer;

    void Awake()
    {
        timer = 1;
    }

    void Update()
    {
        if (timer <= 0 || Input.anyKeyDown)
            Application.Quit();

        timer -= 1 * Time.deltaTime; ;
    }
}

