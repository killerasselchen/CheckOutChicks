//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

class SlipperyWhenWet : PowerUp
{
    public override void Use(Player player)
    {
        //Speichern der Velocity und lerpen zur neuen Vleocity
        GameObject WetFloor = GameObject.Instantiate(player.Wet_Floor_Prefab) as GameObject;
        WetFloor.transform.localRotation = player.transform.localRotation;
        WetFloor.transform.localPosition = new Vector3(player.transform.position.x, WetFloor.transform.position.y, player.transform.position.z);
        WetFloor.GetComponent<SlipperyWhenWetItem>().SetConstructedPlayer(player);
    }
}