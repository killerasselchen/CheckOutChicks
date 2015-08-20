using UnityEngine;

public class TurboBoost : PowerUp
{
    public override void Use(Player player)
    {
        for (int i = 0; i < GameManager.activePlayers.Count; i++)
        {
            if (GameManager.activePlayers[i] == player.gameObject)
            {
                if (GameManager.activePlayers[i].GetComponent<Move>().OnTurbo != true)
                {
                    GameManager.activePlayers[i].GetComponent<Move>().OnTurbo = true;
                    player.gameObject.GetComponentInParent<Rigidbody>().mass -= player.gameObject.GetComponentInParent<Move>().TurboMassBoni;
                }
                //player.gameObject.GetComponentInParent<Move>().AccelerationMultiplier += 0.0f;
            }
        }
    }
}

//GameManager.activePlayers[i].AddComponent<Confuse_Me_Script>();
//Confuse script zerstört sich selbst und wirkt auf den Player