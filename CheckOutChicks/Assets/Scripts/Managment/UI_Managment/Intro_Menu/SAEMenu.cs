//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015
using UnityEngine.UI;
using UnityEngine;

public class SAEMenu : Menu 
{
    public UglyPotatoesIntroMenu UglyPotatoesIntroMenu;

    [SerializeField]
    private float timer;

    void Awake()
    {
        timer = 80;
    }
	
	void Update () 
    {
        timer -= 1;

        if (timer <= 0)
            SwitchToNextScreen();
	}

    private void SwitchToNextScreen()
    {
        UglyPotatoesIntroMenu instance = (UglyPotatoesIntroMenu)GameManager.OpenMenu(UglyPotatoesIntroMenu);
    }
}
