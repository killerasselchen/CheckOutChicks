//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015
using UnityEngine.UI;

public class StoryMenu : Menu
{
    public MainMenu Menu;
    public Button startButton;

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(Menu);
    }

    public void Start()
    {
        startButton.Select();
    }
}