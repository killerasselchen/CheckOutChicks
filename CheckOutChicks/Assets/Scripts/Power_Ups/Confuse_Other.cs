using UnityEngine;
using System.Collections;

class Confuse_Other : Power_Up 
{
    public override void Use(Player player)
    {
        for (int i = 0; i < GameManager.activePlayers.Count; i++)
        {
            if (GameManager.activePlayers[i] != player)
            {
                GameManager.activePlayers[i].GetComponent<Move>().confuse = true;
            }
        }
    }
}
