//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

internal class ConfuseOther : PowerUp
{
    public override void Use(Player player)
    {
        for (int i = 0; i < GameManager.activePlayers.Count; i++)
        {
            if (GameManager.activePlayers[i] != player.gameObject)
            {
                GameManager.activePlayers[i].GetComponent<Move>().IsConfuse = true;
                GameManager.activePlayers[i].GetComponent<Move>().SideStepPower = -1;
                GameManager.activePlayers[i].GetComponent<Move>().SteerMultiplier = -1;
            }
        }
    }
}