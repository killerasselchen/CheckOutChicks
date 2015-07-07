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
                GameManager.activePlayers[i].GetComponent<Move>().turboOn = true;
            }
        }
    }
}
