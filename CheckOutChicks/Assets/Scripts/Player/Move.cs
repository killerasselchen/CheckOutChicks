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
    

    private float turboTimer = 5.0f;
    private float confuseTimer = 5.0f;
    private float stickyTimer = 5.0f;

    private float forwardForcePower = 23;
    public static float forwarPowerUpMultiplier = 1;
    private float sideStepPower = 22.0f;
    private static float sidePowerUpMultiplier = 1;
    private float rotationPower = 2;
    private static float rotationPowerUpMultiplier = 1;

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
	}
	
	void FixedUpdate () 
    {
        GoConfuse();
        GoInSticky();
        GiveTurbo();
        //Debug.Log(forwarPowerUpMultiplier);
        Movement();
	}

    void Movement()
    {
        sideStepForceInput = Input.GetAxis("SideStep_" + playerTag);
        forwardForceInput = Input.GetAxis("Vertical_" + playerTag);
        rotate = Input.GetAxis("Horizontal_" + playerTag);

        Vector3 MoveWagon = new Vector3(sideStepForceInput * sideStepPower * sidePowerUpMultiplier, 0, forwardForceInput * forwardForcePower * forwarPowerUpMultiplier);

        //When i drive Backward i need a invert Input
        Wagon_RB.transform.Rotate(0, rotate * rotationPower * rotationPowerUpMultiplier, 0);
        Wagon_RB.AddRelativeForce(MoveWagon);
    }

    void GoConfuse()
    {
        if (confuse)
        {
            UI_Power_Up.ActivateUI(ui_Power_Up.confuse_Effect);
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
            UI_Power_Up.DeActivateUI(ui_Power_Up.confuse_Effect);
            sidePowerUpMultiplier = 1;
            rotationPowerUpMultiplier = 1;
        }
    }

    void GoInSticky()
    {
        if (inStickyPuddle)
        {
            UI_Power_Up.ActivateUI(ui_Power_Up.sticky_Effect);
            forwarPowerUpMultiplier = 0.2f;
            stickyTimer -= 1.0f * Time.deltaTime;
            if (stickyTimer < 0)
            {
                inStickyPuddle = false;
                stickyTimer = 5.0f;
            }
        }
        else if(!inStickyPuddle)
        {
            UI_Power_Up.DeActivateUI(ui_Power_Up.sticky_Effect);
            forwarPowerUpMultiplier = 1.0f;
        }
    }
    
    void GiveTurbo()
    {
        if(turboOn)
        {
            UI_Power_Up.ActivateUI(ui_Power_Up.turbo_Effect);
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
            UI_Power_Up.DeActivateUI(ui_Power_Up.turbo_Effect);
            forwarPowerUpMultiplier = 1.0f;
        }
    }
    //void BeInPowerFailure()
    //{
    //    if(inPowerFailure)
    //    {

    //    }
    //}
}
