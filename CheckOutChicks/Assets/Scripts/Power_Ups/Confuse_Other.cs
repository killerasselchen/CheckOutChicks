﻿using UnityEngine;
using System.Collections;

public class Confuse_Other : MonoBehaviour {

    //private string powerUpName;
    //private int playerNr;
    //public static bool isUsing = false;

    //// Use this for initialization
    //void Awake () 
    //{
    //    //Here i find the given GameObject Name(of course ..._1(clone) ) and then i split from '_' to '(' and became the playerNr
    //    powerUpName = gameObject.name;
    //    string temp = powerUpName.Split('_', '(')[1];
    //    playerNr = int.Parse(temp);
    //}
    
    //// Update is called once per frame
    //void Update () 
    //{
    //    MovePowerUp();
    //    if (isUsing)
    //    {

    //    }
    //}

    //void MovePowerUp()
    //{
    //    if (playerNr == 1)
    //        this.transform.position = GameManager.camera_1.transform.position;
    //    else if (playerNr == 2)
    //        this.transform.position = GameManager.camera_2.transform.position;
    //    else if (playerNr == 3)
    //        this.transform.position = GameManager.camera_3.transform.position;
    //    else if (playerNr == 4)
    //        this.transform.position = GameManager.camera_4.transform.position;
    //}

    //void ConfuseOther()
    //{
    //    for (int i = 0; i < GameManager.activePlayers.Length; i++)
    //    {
    //        if(i != playerNr)
    //            Player.confuse = true;
    //    }
    //    GameObject.Destroy(this);
    //}
}
