//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private string playerTag;
    public Rigidbody Wagon_RB;

    //For PowerUps
    public bool confuse = false;
    public bool inStickyPuddle = false;
    public bool turboOn = false;
    //public bool inPowerFailure = false;
    //->Timer needs Props for MenuChanges
    private float turboTimer = 2.0f;
    private float confuseTimer = 5.0f;
    public float stickyTimer;
    private float massBoni;

    //For movement
    private float forwardForceInput;
    private float sideStepForceInput;
    private float rotate;

    private float acceleration = 23.0f;
    public float accelerationMultiplier = 1.0f;
    private float sideStepPower = 12.0f;
    private float sideStepMultiplier = 1.0f;
    private float steerPower = 2.0f;
    private float steerMultiplier = 1.0f;
    private float wagonExtraMass = 0;

    private UI_Power_Up ui_Power_Up;

	void Awake () 
    {
        Wagon_RB = GetComponent<Rigidbody>();
        playerTag = gameObject.tag;
        ui_Power_Up = GameObject.Find("UI_" + playerTag).GetComponent<UI_Power_Up>();
        stickyTimer = 4;
        massBoni = 0.6f;
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
        forwardForceInput = Input.GetAxis("Acceleration_" + playerTag);
        rotate = Input.GetAxis("Steer_" + playerTag);

        Vector3 MoveWagon = new Vector3(sideStepForceInput * sideStepPower * sideStepMultiplier, 0, (forwardForceInput * acceleration) * accelerationMultiplier);

        //When i drive Backward i need a invert Input
        Wagon_RB.transform.Rotate(0, rotate * steerPower * steerMultiplier, 0);
        Wagon_RB.AddRelativeForce(MoveWagon);
    }

    void GoConfuse()
    {
        if (confuse)
        {
            sideStepMultiplier = -1;
            steerMultiplier = -1;
            confuseTimer -= 1.0f * Time.deltaTime;
            if (confuseTimer < 0)
            {
                confuse = false;
                confuseTimer = 5.0f;
                sideStepMultiplier = 1;
                steerMultiplier = 1;
            }
        }
    }

    void GoInSticky()
    {
        if(inStickyPuddle)
        {
            if(stickyTimer <= 0)
            {
                inStickyPuddle = false;
                stickyTimer = 4;
                this.gameObject.GetComponent<Rigidbody>().mass -= massBoni;
            }
            stickyTimer -= 1.0f * Time.deltaTime;
        }
    }
    
    void GiveTurbo()
    {
        if(turboOn)
        {
            accelerationMultiplier = 1.25f;
            //Give - on MassBoni!!?
            turboTimer -= 1.0f * Time.deltaTime;

            if (turboTimer < 0)
            {
                turboOn = false;
                turboTimer = 5.0f;
                accelerationMultiplier = 1.0f;
            }
        }
    }

    //void BeInPowerFailure()
    //{
    //    if(inPowerFailure)
    //    {

    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sticky_Puddle" && inStickyPuddle != true)
        {
            inStickyPuddle = true;
            this.gameObject.GetComponent<Rigidbody>().mass += massBoni;
        }
    }
}
