using UnityEngine;

public class TurboBoost : PowerUp
{
    public override void Use(Player player)
    {
        player.GetComponent<Move>().ActivateTurbo();
    }
}
