using UnityEngine;
using System.Collections;

class Sticky_Puddle : Power_Up 
{
    public override void Use(Player player)
    {
        GameObject Puddle = GameObject.Instantiate(player.sticky_Puddle_Prefab) as GameObject;
        Puddle.transform.localPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z -2);
        Puddle.transform.localRotation = player.transform.localRotation;
    }
    
}
