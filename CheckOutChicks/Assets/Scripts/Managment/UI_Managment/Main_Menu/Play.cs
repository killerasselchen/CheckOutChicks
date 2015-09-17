//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

public class Play : Menu
{
    public LevelMenu LevelMenu;
    public MainMenu MainMenu;

    public void BackToMainMenu()
    {
        GameManager.inMainMenu = true;
        GameManager.SetRectsOfMarketCams();
        GameManager.OpenMenu(MainMenu);
    }

    public void SetToFourPlayer()
    {
        GameManager.SetRectsOfMarketCams();
        GameManager.SetToFourPlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }

    public void SetToSinglePlayer()
    {
        GameManager.SetRectsOfMarketCams();
        GameManager.SetToSinglePlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }

    public void SetToThreePlayer()
    {
        GameManager.SetRectsOfMarketCams();
        GameManager.SetToThreePlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }

    public void SetToTwoPlayer()
    {
        GameManager.SetRectsOfMarketCams();
        GameManager.SetToTwoPlayer();
        LevelMenu instance = (LevelMenu)GameManager.OpenMenu(LevelMenu);
    }
}