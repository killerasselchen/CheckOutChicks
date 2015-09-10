public class PointBoost : PowerUp
{
    public override void Use(Player player)
    {
        player.OnPointBoost = true;
    }
}