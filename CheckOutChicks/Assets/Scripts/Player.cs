using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    private string playerTag;
    private int playerNr;
    private string myCam;

    //private GameManager GM;

    public static bool collectItem = false;
    private int maxPlayerPowerUps = 2;
    private int currentPowerUps = 0;

    private int random;

    //Stats for PowerUps
    public static bool confuse = false;
    public static float confuseFloat = 1;
    

	// Use this for initialization
	void Awake () 
    {
        playerTag = gameObject.tag;
        string temp = playerTag.Split('_')[1];
        playerNr = int.Parse(temp);
        //GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        tacho();
        
	}

    public void ChoseItem()
    {
        if (currentPowerUps == 0)
        {
            
            currentPowerUps++;
        }
        else if (currentPowerUps == 1)
        {
            
            currentPowerUps++;
        }
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

    void Confuse(bool leftPowerUp)
    {
        for (int i = 1; i < GameManager.activePlayers.Length; i++)
			{
                if(i != playerNr)
                {
                    Move temp = GameObject.FindGameObjectWithTag("P_" + i).GetComponent<Move>();
                    temp.confuse = true;
                    
                }
			    
			}
    }

    void tacho()
    {
        GameManager.camera_1.GetComponentInChildren<TextMesh>().text = "dudel";
    }
}
 
