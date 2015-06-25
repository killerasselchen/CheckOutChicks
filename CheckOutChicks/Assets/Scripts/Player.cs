using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    private string playerTag;
    private int playerNr;
    private string myCam;
    private int maxPlayerPowerUps = 2;
    private int currentPowerUps = 0;
    private GameObject leftPowerUp;
    private GameObject rightPowerUp;


    private List<bool> itemList = new List<bool>();
    private int random;



	// Use this for initialization
	void Awake () 
    {
        playerTag = gameObject.tag;
        string temp = playerTag.Split('_')[1];
        playerNr = int.Parse(temp) - 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        ShowPowerUps();
        
	    if(Input.GetKey("Fire_Left_" + playerTag))
        {

        }
        if (Input.GetKey("Fire_Right_" + playerTag))
        {

        }
	}

    void ChoseItem()
    {
        if(currentPowerUps == 0)
        {
            random = Random.Range(0, itemList.Capacity);
            leftPowerUp = GameObject.Instantiate(GameManager.powerUps[random], new Vector3(this.transform.position.x - 1,this.transform.position.y + 1,this.transform.position.z -1),Quaternion.identity ) as GameObject;
        }
        else if(currentPowerUps == 1)
        {
            random = Random.Range(0, itemList.Capacity);


        }
        
    }

    void ShowPowerUps()
    {
        leftPowerUp.transform.position = GameManager.cameras[playerNr]).transform.position;
        leftPowerUp.transform.localRotation = Quaternion.identity;

        rightPowerUp.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 1, this.transform.position.z - 1);
        rightPowerUp.transform.localRotation = Quaternion.identity;
    }
}
