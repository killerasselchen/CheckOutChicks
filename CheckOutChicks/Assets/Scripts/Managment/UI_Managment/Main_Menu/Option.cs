//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

public class Option : Menu
{
    public MainMenu Menu;

    public void BackToMainMenu()
    {
        GameManager.OpenMenu(Menu);
    }
}