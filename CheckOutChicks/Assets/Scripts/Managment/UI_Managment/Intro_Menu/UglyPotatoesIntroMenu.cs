//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015
using UnityEngine.UI;
using UnityEngine;

public class UglyPotatoesIntroMenu : Menu
{
    public CheckOutChicksMenu CoCMenu;

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
        CheckOutChicksMenu instance = (CheckOutChicksMenu)GameManager.OpenMenu(CoCMenu);
    }
}