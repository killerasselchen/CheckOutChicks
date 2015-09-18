//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

public class LevelMenu : Menu
{
    public Play PlayMenu;

    public void BackToPlayersMenu()
    {
        Play instance = (Play)GameManager.OpenMenu(PlayMenu);
    }

    public void StartGameInMarketOne()
    {
        GameManager.SelectMarketOne();
        GameManager.StartGame();
    }

    public void StartGameInMarketTwo()
    {
        GameManager.SelectMarketTwo();
        GameManager.StartGame();
    }
}