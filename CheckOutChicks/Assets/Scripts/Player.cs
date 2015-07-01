using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    private string playerTag;
    private int playerNr;
    private string myCam;
    private float speed;
    private Vector3 lastPosition;

    private Power_Up[] powerUps = new Power_Up[2];
    private int random;

	// Use this for initialization
	void Awake () 
    {
        playerTag = gameObject.tag;
        string temp = playerTag.Split('_')[1];
        playerNr = int.Parse(temp);
        //GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        lastPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        tacho();
	}

    void ChoseItem()
    {
        int tempSelection = Random.Range(0, GameManager.availablePowerUps.Count);

    }

    void SetPowerUp(Power_Up PowerUp)
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            if(powerUps[i] == null)
            {
                powerUps[i] = GameManager.availablePowerUps[Random.Range(0, GameManager.availablePowerUps.Count)];
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Power_Up")
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
           if(powerUps[0] != null)
           {
               powerUps[0].Use(this);
               powerUps[0] = null;
           }
        }
        if (Input.GetKey("Fire_Right_" + playerTag))
        {
            powerUps[1].Use(this);
            powerUps[1] = null;
        }
    }

    void tacho()
    {
        Debug.Log("@TachoStart");

        for (int i = 0; i < GameManager.activeCameras.Count; i++)
        {
            Debug.Log("@time");
            speed = (this.transform.position - lastPosition).magnitude / Time.deltaTime;

            if (i+1 == playerNr)
            {
                Debug.Log("@TextMesh");

                GameManager.activeCameras[i].GetComponentInChildren<TextMesh>().text = speed.ToString("0.");
                lastPosition = this.transform.position;
            }
        }
    }
}
 
