using UnityEngine;
using System.Collections;

class Sticky_Puddle : Power_Up 
{
    public override void Use(Player player)
    {
        GameObject Puddle = GameObject.Instantiate(player.sticky_Puddle_Prefab) as GameObject;
        Puddle.transform.localPosition = new Vector3(player.transform.localPosition.x, Puddle.transform.position.y, player.transform.localPosition.z);
        Puddle.transform.localRotation = player.transform.localRotation;
    }
    
}
