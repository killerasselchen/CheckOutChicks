using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    public GameObject sticky_Puddle_Prefab;


    private string playerTag;
    private int playerNr;
    private string myCam;
    private float speed;
    private float myPoints;

    public float MyPoints
    {
        get { return myPoints; }
        set { myPoints = value; }
    }

    //Outsourcing lastPos
    //private Vector3 lastPosition;

    private Power_Up[] myPowerUps = new Power_Up[2];
    private int random;
    private int tempItem;
    public static int leftItem;
    public static int rightItem;
    private Power_Up nextPowerUp;

    private UI_Power_Up ui_Power_Up;
    private TextMesh ui_Points;
    private Shopping_Manager shopping_Manager;
    private Power_Up_Manager power_Up_Manager;
    //public Arrow[] arrows;

    private List<string> meineEinkaeufe = new List<string>();

	// Use this for initialization
	void Awake () 
    {
        playerTag = gameObject.tag;
        //string temp = playerTag.Split('_')[1];
        //playerNr = int.Parse(temp);
        ui_Power_Up = GameObject.Find("UI_" + playerTag).GetComponent<UI_Power_Up>();
        ui_Points = GameObject.Find("Points_" + playerTag).GetComponent<TextMesh>();
        shopping_Manager = GameObject.Find("GameManager").GetComponent<Shopping_Manager>();
        power_Up_Manager = GameObject.Find("GameManager").GetComponent<Power_Up_Manager>();
	}

    //public void OnEnable()
    //{
    //    shopping_Manager.OnCreateItem += OnItemCreation;
    //}

    //public void OnDisable()
    //{
    //    shopping_Manager.OnCreateItem -= OnItemCreation;
    //}

	void Update () 
    {
        //tacho();
        if (Input.anyKeyDown)
            UsePowerUp();
        ui_Points.text = MyPoints.ToString("0.0");
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
                    //Über Event lösen?!!!
                    UI_Power_Up.ActivateUI(ui_Power_Up.leftPowerUps[leftItem]);
                }
                else if(i == 1)
                {
                    rightItem = tempItem;
                    //Über Event lösen?!!!
                    UI_Power_Up.ActivateUI(ui_Power_Up.rightPowerUps[rightItem]);
                }
                myPowerUps[i] = powerUp;
                return;
            }
        }
    }

    void UsePowerUp()
    {
        if (Input.GetButtonDown("Fire_Left_" + playerTag))
        {
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
        tempItem = Random.Range(0, power_Up_Manager.AvailablePowerUp.Length);
        nextPowerUp = power_Up_Manager.AvailablePowerUp[tempItem];
        //nextPowerUp = power_Up_Manager.availablePowerUps[tempItem];

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Power_Up_Spawn_Point")
        {
            SetNextPowerUp();
            SetPowerUp(nextPowerUp);
            other.gameObject.SetActive(false);
            power_Up_Manager.CurrentMapPowerUps--;
        }

        else if(other.tag == "Product")
        {
            meineEinkaeufe.Add(other.gameObject.name);
            SetPoints(other.gameObject.GetComponent<Item>());
            other.gameObject.SetActive(false);
            shopping_Manager.Products.Remove(other.gameObject);
            //shopping_Manager.Products.Remove(shopping_Manager.Products[shopping_Manager.NextItem]);
            //shopping_Manager.CurrentItems = shopping_Manager.CurrentItems - 1;

            //other.gameObject.GetComponent<Item>().Deactivate;
        }

        //else if(other.tag == "Player")
        //{
        //    other.collider.transform.po
        //}

        
    }


    void SetPoints(Item currentItem)
    {
            MyPoints += 25;

            MyPoints += currentItem.TimeBoni;
    }

    //private void OnItemCreation(Item newItem)
    //{
    //    //Richtigen Pfeil finden Logik hier
    //    for (int i = 0; i < arrows.Length; i++)
    //    {
    //        if (!arrows[i].gameObject.activeInHierarchy) //active in herachie???
    //        {
    //            arrows[i].gameObject.SetActive(true);
    //            arrows[i].PointToTarget(newItem);
    //            return;
    //        }
    //    }
    //}

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
 
