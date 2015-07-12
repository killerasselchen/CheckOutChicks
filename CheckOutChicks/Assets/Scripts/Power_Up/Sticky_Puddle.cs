using UnityEngine;
using System.Collections;

class Sticky_Puddle : Power_Up 
{
    public override void Use(Player player)
    {
        for (int i = 0; i < GameManager.activePlayers.Count; i++)
        {
            if (GameManager.activePlayers[i] == player.gameObject) continue;
            {
                GameManager.activePlayers[i].GetComponent<Move>().inStickyPuddle = true;
            }
        }
    }
    
}
