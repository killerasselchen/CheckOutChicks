using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    private string playerNr;
    private int maxPlayerPowerUps = 2;
    private string leftPowerUp;
    private string rightPowerUp;
    private bool hasFlashOther;
    private bool hasBetterSteering;

    private bool[] itemList = new bool[2] { true, false };



	// Use this for initialization
	void Awake () 
    {
        playerNr = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKey("Fire_Left_" + playerNr))
        {
            
        }
        if (Input.GetKey("Fire_Right_" + playerNr))
        {

        }
	}
}
