//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

//Sublime Text
//str + K + D = Format Document
//

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform cameraPosition;

    #region Timer

    private float pointBoosterTimer;
    private float pointBoosterTimerOriganal = 10.0f;

    #endregion Timer
    public Vector3 Velocity;

    private List<string> myPurchases = new List<string>();

    [SerializeField]
    private float myPoints;

    private PowerUp[] myPowerUps = new PowerUp[2];

    private PowerUp nextPowerUp;

    private bool onPointBoost = false;

    private string playerTag;
    
    public PowerUpManager power_Up_Manager;

    [SerializeField]
    private Rigidbody RB;

    public ShoppingManager shopping_Manager;

    [SerializeField]
    private GameObject sticky_Puddle_Prefab;

    private int tempItem;

    public Text ui_Points;

    public PowerUpUI ui_Power_Up;

    [SerializeField]
    private GameObject wet_Floor_Prefab;

    public float MyPoints
    {
        //TODO: Doesnt Work. PointBoost kicks Point in Infinity in few Sek
        get { return myPoints; }
        set
        {
            if (onPointBoost)
                myPoints = value + value;
            else
                myPoints = value;
        }
    }

    public bool OnPointBoost
    {
        get { return onPointBoost; }
        set { onPointBoost = value; }
    }

    public GameObject Sticky_Puddle_Prefab
    {
        get { return sticky_Puddle_Prefab; }
    }
    public GameObject Wet_Floor_Prefab
    {
        get { return wet_Floor_Prefab; }
    }
    private void Awake()
    {
        playerTag = gameObject.tag;
        //ui_Power_Up = GameObject.Find("UI_Player_" + playerTag.Split('_','(')[1]).GetComponent<PowerUpUI>();
        //ui_Points = GameObject.Find("Points_Player_" + playerTag.Split('_','(')[1]).GetComponent<TextMesh>();
        //shopping_Manager = GameObject.Find("GameManager").GetComponent<ShoppingManager>();
        //power_Up_Manager = GameObject.Find("GameManager").GetComponent<PowerUpManager>();
    }

    private void FixedUpdate()
    {
        if (Input.anyKeyDown)
            UsePowerUp();
        else if (onPointBoost)
            PointBoost();
        ui_Points.text = MyPoints.ToString("0");
        Velocity = RB.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Power_Up_Spawn_Point")
        {
            SetNextPowerUp();
            SetPowerUp(nextPowerUp);
            other.gameObject.SetActive(false);
            power_Up_Manager.CurrentMapPowerUps--;
        }

        if (other.tag == "Product")
        {
            myPurchases.Add(other.gameObject.name);
            SetPointsForItems(other.gameObject.GetComponent<Item>());
            other.gameObject.SetActive(false);
            shopping_Manager.Products.Remove(other.gameObject);
        }
    }

    private void PointBoost()
    {
        if (pointBoosterTimer <= 0)
        {
            onPointBoost = false;
            pointBoosterTimer = pointBoosterTimerOriganal;
        }

        pointBoosterTimer -= 1.0f * Time.deltaTime;
    }

    private void SetNextPowerUp()
    {
        tempItem = Random.Range(0, power_Up_Manager.AvailablePowerUp.Length);
        nextPowerUp = power_Up_Manager.AvailablePowerUp[tempItem];
    }

    private void SetPointsForItems(Item currentItem)
    {
        //Points for every Item
        MyPoints += 25;
        //Extra Points for fast collecting after spawn
        MyPoints += currentItem.TimeBoni;
    }

    private void SetPowerUp(PowerUp powerUp)
    {
        for (int i = 0; i < myPowerUps.Length; i++)
        {
            if (myPowerUps[i] == null)
            {
                ui_Power_Up.SetImage(i, power_Up_Manager.PowerUpIcons[tempItem]);
                myPowerUps[i] = powerUp;
                return;
            }
        }
    }

    private void UsePowerUp()
    {
        if (Input.GetButtonDown("Fire_Left_" + playerTag))
        {
            if (myPowerUps[0] != null)
            {
                myPowerUps[0].Use(this);
                myPowerUps[0] = null;
                ui_Power_Up.ClearImage(0);
            }
        }
        if (Input.GetButtonDown("Fire_Right_" + playerTag))
        {
            if (myPowerUps[1] != null)
            {
                myPowerUps[1].Use(this);
                myPowerUps[1] = null;
                ui_Power_Up.ClearImage(1);
            }
        }
    }
}