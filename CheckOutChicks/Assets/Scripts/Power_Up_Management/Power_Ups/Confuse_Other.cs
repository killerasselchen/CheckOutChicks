//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;


//the Player! doesnt work

class Confuse_Other : Power_Up 
{
    public override void Use(Player player)
    {
        for (int i = 0; i < GameManager.activePlayers.Count; i++)
        {
            Debug.Log("toller text: "+GameManager.activePlayers[i]);
            if (GameManager.activePlayers[i] != player.gameObject)
            {
                GameManager.activePlayers[i].GetComponent<Move>().confuse = true;
                Debug.Log("who activate: " + player.gameObject);
                Debug.Log("In list: " + GameManager.activePlayers[i].name);
            }
        }
    }
}
