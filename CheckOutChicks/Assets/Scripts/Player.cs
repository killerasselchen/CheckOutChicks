using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    private string playerTag;
    private int playerNr;
    private string myCam;
    private float speed;
    private Vector3 lastPosition;

    private Power_Up[] myPowerUps = new Power_Up[2];
    private int random;
    private int tempItem;
    public static int leftItem;
    public static int rightItem;
    private Power_Up nextPowerUp;
    private string leftPowerUpTexture;
    private string rightPowerUpTexture;

    private UI_Power_Up ui_Power_Up;
    private Shopping_Manager shopping_Manager;

    private List<string> meineEinkaeufe;

	// Use this for initialization
	void Awake () 
    {
        playerTag = gameObject.tag;
        string temp = playerTag.Split('_')[1];
        playerNr = int.Parse(temp);
        //GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        lastPosition = this.transform.position;
        ui_Power_Up = GameObject.Find("Canvas_" + playerTag).GetComponent<UI_Power_Up>();
        shopping_Manager = GameObject.Find("GameManager").GetComponent<Shopping_Manager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //tacho();
        if (Input.anyKeyDown)
            UsePowerUp();
	}

    void SetPowerUp(Power_Up powerUp)
    {
        for (int i = 0; i < myPowerUps.Length; i++)
        {
            if(myPowerUps[i] == null)
            {
                if(i == 0)
                {
                    leftItem = tempItem;
                    UI_Power_Up.ActivateUI(ui_Power_Up.leftPowerUps[leftItem]);
                }
                else if(i == 1)
                {
                    rightItem = tempItem;
                    UI_Power_Up.ActivateUI(ui_Power_Up.rightPowerUps[rightItem]);
                }
                myPowerUps[i] = powerUp;
                Debug.Log(myPowerUps[i]);
                return;
            }
        }
    }

    void SelectItem(int itemNr)
    {

    }

    void UsePowerUp()
    {
        if (Input.GetButtonDown("Fire_Left_" + playerTag))
        {
            Debug.Log("leftFire" + playerNr);
           if(myPowerUps[0] != null)
           {
               myPowerUps[0].Use(this);
               myPowerUps[0] = null;
               UI_Power_Up.DeActivateUI(ui_Power_Up.leftPowerUps[leftItem]);
           }
        }
        if (Input.GetButtonDown("Fire_Right_" + playerTag))
        {
            if (myPowerUps[1] != null)
            {
                myPowerUps[1].Use(this);
                myPowerUps[1] = null;
                UI_Power_Up.DeActivateUI(ui_Power_Up.rightPowerUps[rightItem]);
            }
        }
    }

    void SetNextPowerUp()
    {
        tempItem = Random.Range(0, GameManager.availablePowerUps.Length);
        nextPowerUp = GameManager.availablePowerUps[tempItem];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Power_Up")
        {
            SetNextPowerUp();
            SetPowerUp(nextPowerUp);
            other.gameObject.SetActive(false);
            GameManager.currentMapPowerUps--;
        }

        else if(other.tag == "Product")
        {
            meineEinkaeufe.Add(other.gameObject.name);
            other.gameObject.SetActive(false);
            shopping_Manager.Products.Remove(other.gameObject);
            //shopping_Manager.Products.Remove(shopping_Manager.Products[shopping_Manager.NextItem]);
            shopping_Manager.CurrentItem--;
        }
    }

    //Must be OUTSOURCE!!
    //void tacho()
    //{
    //    for (int i = 0; i < GameManager.activeCameras.Count; i++)
    //    {
    //        Debug.Log("@time");
    //        speed = (this.transform.position - lastPosition).magnitude / Time.deltaTime;
    //        speed = speed * 100;

    //        if (i + 1 == playerNr)
    //        {
    //            Debug.Log("@TextMesh");

    //            GameManager.activeCameras[i].GetComponentInChildren<TextMesh>().text = speed.ToString("0.");
    //            lastPosition = this.transform.position;
    //        }
    //    }
    //}
}
 
