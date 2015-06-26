using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    private string playerTag;
    private int playerNr;
    private string myCam;

    public static bool collectItem = false;
    private int maxPlayerPowerUps = 2;
    private int currentPowerUps = 0;
    private GameObject leftPowerUp ;
    private GameObject rightPowerUp;

    private int random;

	// Use this for initialization
	void Awake () 
    {
        playerTag = gameObject.tag;
        string temp = playerTag.Split('_')[1];
        playerNr = int.Parse(temp) - 1;
        leftPowerUp = new GameObject();
        rightPowerUp = new GameObject();
	}
	
	// Update is called once per frame
	void Update () 
    {
        ShowPowerUps();
        
        
	}

    public void ChoseItem()
    {
        if (currentPowerUps == 0)
        {
            Debug.Log("Erstellt!! Left");
            random = Random.Range(0, GameManager.powerUps.Length);
            leftPowerUp = GameObject.Instantiate(GameManager.powerUps[random]) as GameObject;
            leftPowerUp.name = "leftPowerUp_" + playerNr;
            currentPowerUps++;
        }
        else if (currentPowerUps == 1)
        {
            random = Random.Range(0, GameManager.powerUps.Length);
            rightPowerUp = GameObject.Instantiate(GameManager.powerUps[random]) as GameObject;
            rightPowerUp.name = "rightPowerUp_" + playerNr;
            currentPowerUps++;
        }
    }

    void ShowPowerUps()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Power_Up") //Later "Power_Up"
        {
            Debug.Log("Fuck Up??");
            ChoseItem();
            other.gameObject.SetActive(false);
            GameManager.currentMapPowerUps--;
        }
    }

    void UsePowerUp()
    {
        //if(Input.)
        if (Input.GetKey("Fire_Left_" + playerTag))
        {

        }
        if (Input.GetKey("Fire_Right_" + playerTag))
        {

        }
    }
}
 
