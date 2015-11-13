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
    private GameObject booomFeedback;

    [SerializeField]
    private AudioSource cantCollectedPowerUp;

    [SerializeField]
    private AudioClip chipsSound;

    [SerializeField]
    private AudioClip colaSound;

    [SerializeField]
    private AudioSource collectedItem;

    [SerializeField]
    private AudioSource collectedPowerUp;

    private Transform collisionPoint;

    [SerializeField]
    private AudioClip crashSound;

    [SerializeField]
    private AudioSource haveNoPowerUpToUse;

    [SerializeField]
    private float myPoints;

    private PowerUp[] myPowerUps = new PowerUp[2];

    private List<string> myPurchases = new List<string>();

    private PowerUp nextPowerUp;

    private bool onPointBoost = false;

    private string playerTag;

    [SerializeField]
    private GameObject powFeedback;

    [SerializeField]
    private Rigidbody RB;

    [SerializeField]
    private GameObject sticky_Puddle_Prefab;

    private int tempItem;

    [SerializeField]
    private AudioSource usePowerUp;

    #region Timer

    public float PointBoosterTimer;
    public float PointBoosterTimerOriganal = 15.0f;

    #endregion Timer

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

    public void MakeMeToWinner()
    {
        WinnerText.text = "Winner";
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
        Tacho();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Interieur")
        {
            if (speed >= 3f)
                InstantiateBooom(other.contacts[0].point);
        }
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
        else if (other.tag == "Interieur")
        {
            AddPoints(-5);
        }
        else if (other.tag == "Wagon" && speed >= 2f)
        {
            InstantiatePow(other.transform.position);
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
                Debug.Log("fire one");
                myPowerUps[0].Use(this);
                myPowerUps[0] = null;
                //usePowerUp.Play();
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
                Debug.Log("fire one");
                myPowerUps[1].Use(this);
                myPowerUps[1] = null;
                //usePowerUp.Play();
                Ui_Power_Up.ClearImage(1);
            }
            else
            {
                haveNoPowerUpToUse.Play();
            }
        }
    }

    #region PlayerFeedback

    private Vector3 lastPosition;
    private float speed;

    private void InstantiateBooom(Vector3 collisionPoint)
    {
        GameObject feedback = Instantiate(booomFeedback, collisionPoint, Quaternion.identity) as GameObject;
        feedback.GetComponent<Visual_Player_Feedbacks>().MyTarget = this;
        feedback.GetComponent<Visual_Player_Feedbacks>().FeedbackPosition = collisionPoint;
    }

    private void InstantiatePow(Vector3 collisionPoint)
    {
        GameObject feedback = Instantiate(powFeedback, collisionPoint, Quaternion.identity) as GameObject;
        feedback.GetComponent<Visual_Player_Feedbacks>().MyTarget = this;
        feedback.GetComponent<Visual_Player_Feedbacks>().FeedbackPosition = collisionPoint;
    }

    private void Tacho()
    {
        speed = (this.transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = this.transform.position;
        Debug.Log("Speed: " + speed);
    }

    #endregion PlayerFeedback
}