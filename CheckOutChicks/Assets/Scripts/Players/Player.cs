//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform CameraPosition;

    public Transform CameraTarget;

    public PowerUpManager Power_Up_Manager;

    public ShoppingManager Shopping_Manager;

    public Text Ui_Points;

    public PowerUpUI Ui_Power_Up;

    public Vector3 Velocity;

    public TextMesh WinnerText;

    [SerializeField]
    private AudioClip chipsSound;

    [SerializeField]
    private AudioClip colaSound;

    [SerializeField]
    private AudioClip crashSound;

    [SerializeField]
    private AudioSource collectedPowerUp;

    [SerializeField]
    private AudioSource cantCollectedPowerUp;

    [SerializeField]
    private AudioSource collectedItem;

    [SerializeField]
    private AudioSource usePowerUp;

    [SerializeField]
    private AudioSource haveNoPowerUpToUse;

    #region Timer

    public float PointBoosterTimer;
    public float PointBoosterTimerOriganal = 15.0f;

    #endregion Timer

    [SerializeField]
    private float myPoints;

    private PowerUp[] myPowerUps = new PowerUp[2];

    private List<string> myPurchases = new List<string>();

    private PowerUp nextPowerUp;

    private bool onPointBoost = false;

    private string playerTag;

    [SerializeField]
    private Rigidbody RB;

    [SerializeField]
    private GameObject sticky_Puddle_Prefab;

    private int tempItem;

    [SerializeField]
    private GameObject wet_Floor_Prefab;

    public float MyPoints
    {
        get { return myPoints; }
        set { myPoints = value; }
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

    public void AddPoints(float points)
    {
        if (onPointBoost)
            myPoints += points * 2;
        else
            myPoints += points;
    }

    private void Awake()
    {
        playerTag = gameObject.tag;
    }

    private void FixedUpdate()
    {
        if (Input.anyKeyDown)
            UsePowerUp();
        else if (onPointBoost)
            PointBoost();
        Ui_Points.text = MyPoints.ToString("0");
        Velocity = RB.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Power_Up_Spawn_Point")
        {
            SetNextPowerUp();
            SetPowerUp(nextPowerUp);
            other.gameObject.SetActive(false);
            Power_Up_Manager.CurrentMapPowerUps--;
        }

        else if (other.tag == "Product")
        {
            collectedItem.Play();
            myPurchases.Add(other.gameObject.name);
            SetPointsForItems(other.gameObject.GetComponent<Item>());
            Shopping_Manager.EnqueueItem(other.gameObject);
        }

        else if(other.tag == "Interieur")
        {
            AddPoints(-5);
        }
    }

    private void PointBoost()
    {
        if (PointBoosterTimer <= 0)
        {
            onPointBoost = false;
            PointBoosterTimer = PointBoosterTimerOriganal;
        }

        PointBoosterTimer -= 1.0f * Time.deltaTime;
    }

    private void SetNextPowerUp()
    {
        tempItem = Random.Range(0, Power_Up_Manager.AvailablePowerUp.Length);
        nextPowerUp = Power_Up_Manager.AvailablePowerUp[tempItem];
    }

    private void SetPointsForItems(Item currentItem)
    {
        MyPoints += 25;
        MyPoints += currentItem.TimeBoni;
    }

    private void SetPowerUp(PowerUp powerUp)
    {
        for (int i = 0; i < myPowerUps.Length; i++)
        {
            if (myPowerUps[i] == null)
            {
                collectedPowerUp.Play();
                Ui_Power_Up.SetImage(i, Power_Up_Manager.PowerUpIcons[tempItem]);
                myPowerUps[i] = powerUp;
                return;
            }
            else
            {
                cantCollectedPowerUp.Play();
            }
        }
    }

    private void UsePowerUp()
    {
        if (Input.GetButtonDown("Fire_Left_" + playerTag))
        {
            if (myPowerUps[0] != null)
            {
                usePowerUp.Play();
                myPowerUps[0].Use(this);
                myPowerUps[0] = null;
                Ui_Power_Up.ClearImage(0);
            }
            else
            {
                haveNoPowerUpToUse.Play();
            }
        }
        if (Input.GetButtonDown("Fire_Right_" + playerTag))
        {
            if (myPowerUps[1] != null)
            {
                usePowerUp.Play();
                myPowerUps[1].Use(this);
                myPowerUps[1] = null;
                Ui_Power_Up.ClearImage(1);
            }
            else
            {
                haveNoPowerUpToUse.Play();
            }
        }
    }

    public void MakeMeToWinner()
    {
        WinnerText.text = "Winner";
    }
}