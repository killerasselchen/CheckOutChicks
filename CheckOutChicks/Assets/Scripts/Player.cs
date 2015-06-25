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
    private GameObject leftPowerUp = new GameObject();
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

    public void ChoseItem()
    {
        if(currentPowerUps == 0)
        {
            Debug.Log("Erstellt!! Left");
            random = Random.Range(0, itemList.Capacity);
            leftPowerUp = GameObject.Instantiate(GameManager.powerUps[random]) as GameObject;
        }
        else if(currentPowerUps == 1)
        {
            random = Random.Range(0, itemList.Capacity);
            rightPowerUp = GameObject.Instantiate(GameManager.powerUps[random]) as GameObject;
        }
    }

    void ShowPowerUps()
    {
        // HIER...............nicht gesetzt!???

        Vector3 temp = GameManager.cameras[playerNr].transform.position;
        Quaternion temp2 = GameManager.cameras[playerNr].transform.localRotation;
        //leftPowerUp.transform.position = GameManager.cameras[playerNr].transform.position;
        leftPowerUp.transform.position = new Vector3(temp.x + 1, temp.y + 1, temp.z - 1);
        leftPowerUp.transform.localRotation = temp2;

        rightPowerUp.transform.position = new Vector3(temp.x + 1, temp.y + 1, temp.z - 1);
        rightPowerUp.transform.localRotation = temp2;
    }

    void OnCollisionEnter(Collider other)
    {
        if(other.tag == "Power_Up") //Later "Power_Up"
        {
            Debug.Log("Fuck Up??");
            ChoseItem();
            other.gameObject.SetActive(false);
            GameManager.currentMapPowerUps--;
        }
    }
}
 //if(other.gameObject.tag == "Power_Up") //Later "Power_Up"
 //       {
 //           Debug.Log("Fuck Up??");
 //           ChoseItem();
 //           other.gameObject.SetActive(false);
 //           GameManager.currentMapPowerUps--;
 //       }
