//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

class Slippery_When_Wet : Power_Up
{
    public override void Use(Player player)
    {
        GameObject Puddle = GameObject.Instantiate(player.wet_Floor_Prefab) as GameObject;
        Puddle.transform.localRotation = player.transform.localRotation;
        Puddle.transform.localPosition = new Vector3(player.transform.position.x, Puddle.transform.position.y, player.transform.position.z);
        Puddle.GetComponent<Item_Sticky_Puddle>().SetConstructedPlayer(player);
    }
}