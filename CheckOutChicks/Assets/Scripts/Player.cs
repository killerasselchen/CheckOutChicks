using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    private string playerTag;
    private int playerNr;
    private string myCam;
    private float speed;
    private Vector3 lastPosition;

    private GameManager GM;

    public static bool collectItem = false;
    private int maxPlayerPowerUps = 2;
    private int currentPowerUps = 0;

    private int random;

    //Stats for PowerUps

    public static bool confuse = false;
    

	// Use this for initialization
	void Awake () 
    {
        playerTag = gameObject.tag;
        string temp = playerTag.Split('_')[1];
        playerNr = int.Parse(temp);
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        lastPosition = this.transform.position;
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
            ChoseItem();
            other.gameObject.SetActive(false);
            GameManager.currentMapPowerUps--;
        }
    }

    void UsePowerUp()
    {
        if (Input.GetKey("Fire_Left_" + playerTag))
        {
           
        }
        if (Input.GetKey("Fire_Right_" + playerTag))
        {

        }
    }

    //void Confuse()
    //{
    //    for (int i = 1; i < GM.activePlayers.Count; i++)
    //    {
    //        if(i != playerNr)
    //        {
    //            Move temp = GameObject.FindGameObjectWithTag("P_" + i).GetComponent<Move>();
    //            temp.confuse = true;
    //        }
    //    }
    //}

    void tacho()
    {
        Debug.Log("@TachoStart");

        for (int i = 0; i < GM.activeCameras.Count; i++)
        {
            Debug.Log("@time");
            speed = (this.transform.position - lastPosition).magnitude / Time.deltaTime;

            if (i+1 == playerNr)
            {
                Debug.Log("@TextMesh");

                GM.activeCameras[i].GetComponentInChildren<TextMesh>().text = speed.ToString("0.");
                lastPosition = this.transform.position;
            }
        }
    }
}
 
