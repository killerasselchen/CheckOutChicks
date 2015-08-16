using UnityEngine;
using System.Collections;

public class Turbo_Boost : Power_Up 
{
    public override void Use(Player player)
    {
        for (int i = 0; i < GameManager.activePlayers.Count; i++)
        {
            if (GameManager.activePlayers[i] == player.gameObject)
            {
                if (GameManager.activePlayers[i].GetComponent<Move>().OnTurbo != true)
                    GameManager.activePlayers[i].GetComponent<Move>().OnTurbo = true;
                //player.gameObject.GetComponentInParent<Move>().AccelerationMultiplier += 0.0f;
                player.gameObject.GetComponentInParent<Rigidbody>().mass -= player.gameObject.GetComponentInParent<Move>().TurboMassBoni;
            }
        }
    }
}
