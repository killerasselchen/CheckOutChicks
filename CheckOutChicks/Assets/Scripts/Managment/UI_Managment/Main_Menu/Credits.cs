//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine.UI;


public class Credits : Menu
{
    public Button startButton;

    public MainMenu MainMenu;

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(MainMenu);
    }
    public void Start()
    {
        startButton.Select();
    }
}