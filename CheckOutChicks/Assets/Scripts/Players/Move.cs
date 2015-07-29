//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Rigidbody Wagon_RB;

    //For PowerUps
    public bool confuse = false;
    public bool inStickyPuddle = false;
    public bool turboOn = false;
    //public bool inPowerFailure = false;
    

    private float turboTimer = 2.0f;
    private float confuseTimer = 5.0f;
    public float stickyTimer;
    private float stickyPower;

    private float forwardForcePower = 23.0f;
    public static float forwarPowerUpMultiplier = 1.0f;
    private float sideStepPower = 12.0f;
    private static float sidePowerUpMultiplier = 1.0f;
    private float rotationPower = 2.0f;
    private static float rotationPowerUpMultiplier = 1.0f;
    private static float wagonExtraMass = 0;
    private string playerTag;

    float forwardForceInput;
    public float sideStepForceInput;
    public float rotate;

    private UI_Power_Up ui_Power_Up;

	void Awake () 
    {
        Wagon_RB = GetComponent<Rigidbody>();
        playerTag = gameObject.tag;
        ui_Power_Up = GameObject.Find("UI_" + playerTag).GetComponent<UI_Power_Up>();
        stickyTimer = 4;
        stickyPower = 0.4f;
	}
	
	void FixedUpdate () 
    {
        Movement();
	}

    void Update()
    {
        GoInSticky();
        GoConfuse();
        GiveTurbo();
    }

    void Movement()
    {
        sideStepForceInput = Input.GetAxis("SideStep_" + playerTag);
        forwardForceInput = Input.GetAxis("Vertical_" + playerTag);
        rotate = Input.GetAxis("Horizontal_" + playerTag);

        Vector3 MoveWagon = new Vector3(sideStepForceInput * sideStepPower * sidePowerUpMultiplier, 0, (forwardForceInput * forwardForcePower) * forwarPowerUpMultiplier);

        //When i drive Backward i need a invert Input
        Wagon_RB.transform.Rotate(0, rotate * rotationPower * rotationPowerUpMultiplier, 0);
        Wagon_RB.AddRelativeForce(MoveWagon);
    }

    void GoConfuse()
    {
        if (confuse)
        {
            sidePowerUpMultiplier = -1;
            rotationPowerUpMultiplier = -1;
            confuseTimer -= 1.0f * Time.deltaTime;
            if (confuseTimer < 0)
            {
                confuse = false;
                confuseTimer = 5.0f;
            }
        }
        else if (!confuse)
        {
            sidePowerUpMultiplier = 1;
            rotationPowerUpMultiplier = 1;
        }
    }

    void GoInSticky()
    {
        if(stickyTimer <= 0)
        {
            inStickyPuddle = false;
            stickyTimer = 4;
            this.gameObject.GetComponent<Rigidbody>().mass -= stickyPower;
        }

        else if(inStickyPuddle)
        {
            stickyTimer -= 1.0f * Time.deltaTime;
        }
    }
    
    void GiveTurbo()
    {
        if(turboOn)
        {
            //UI_Power_Up.ActivateUI(ui_Power_Up.turbo_Effect);
            forwarPowerUpMultiplier = 1.5f;
            turboTimer -= 1.0f * Time.deltaTime;

            if (turboTimer < 0)
            {
                turboOn = false;
                turboTimer = 5.0f;
            }
        }
        else if(!turboOn)
        {
            //UI_Power_Up.DeActivateUI(ui_Power_Up.turbo_Effect);
            forwarPowerUpMultiplier = 1.0f;
        }
    }
    //void BeInPowerFailure()
    //{
    //    if(inPowerFailure)
    //    {

    //    }
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Sticky_Puddle")
    //    {
    //        //inStickyPuddle = true;
    //        this.gameObject.GetComponent<Rigidbody>().mass += 0.6f;
    //        Debug.Log("Give Mass ++");
    //    }
    //}
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sticky_Puddle" && inStickyPuddle != true)
        {
            inStickyPuddle = true;
            this.gameObject.GetComponent<Rigidbody>().mass += stickyPower;
        }
    }
}
