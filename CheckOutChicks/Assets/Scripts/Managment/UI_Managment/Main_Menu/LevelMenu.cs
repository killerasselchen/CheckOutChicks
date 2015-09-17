public class LevelMenu : Menu
{
    public Play PlayMenu;
    public InGame inGame;

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