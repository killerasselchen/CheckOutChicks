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
    //Needs Props to not longer public
    public bool IsConfuse = false;
    public bool OnTurbo = false;
    private bool inStickyPuddle = false;
    private bool onSlipperyWet = false;
    //private bool isHollow = false;

    private float stickyMassBoni;
    
    public float StickyMassBoni
    {
        get { return stickyMassBoni; }
        set { stickyMassBoni = value; }
    }

    private float turboMassBoni;

    public float TurboMassBoni
    {
        get { return turboMassBoni; }
        set { turboMassBoni = value; }
    }

    //->Timer needs Props for MenuChanges
    private float turboTimerOriginal = 2.0f;
    private float turboTimer;
    private float confuseTimerOriginal = 5.0f;
    private float confuseTimer;
    private float stickyTimerOriginal = 5.0f;
    private float stickyTimer;
    private float slipperyWhenWetTimerOriginal = 5.0f;
    private float slipperyWhenWetTimer;


    //For movement
    private float forwardForceInput;
    private float sideStepForceInput;
    private float rotate;

    private float acceleration = 23.0f;
    private float accelerationMultiplier = 1.0f;
    private float sideStepPower = 12.0f;
    private float sideStepMultiplier = 1.0f;
    private float steerPower = 2.0f;
    private float steerMultiplier = 1.0f;
    private float wagonExtraMass = 0;

    public float AccelerationMultiplier
    {
        get { return accelerationMultiplier; }
        set { accelerationMultiplier = value; }
    }

    public float SideStepPower
    {
        get { return sideStepMultiplier; }
        set { sideStepMultiplier = value; }
    }
    
    public float SteerMultiplier
    {
        get { return steerMultiplier; }
        set { steerMultiplier = value; }
    }

    private UI_Power_Up ui_Power_Up;

	void Awake () 
    {
        Wagon_RB = GetComponent<Rigidbody>();
        playerTag = gameObject.tag;
        ui_Power_Up = GameObject.Find("UI_" + playerTag).GetComponent<UI_Power_Up>();
        TimerSettings();
        StickyMassBoni = 0.8f;
        TurboMassBoni = 0.3f;
	}
	
	void FixedUpdate () 
    {
        Movement();
	}

    void Movement()
    {
        if(inStickyPuddle)
            InSticky();

        else if (IsConfuse)
            Confuse();

        else if (OnTurbo)
            Turbo();

        sideStepForceInput = Input.GetAxis("SideStep_" + playerTag);
        forwardForceInput = Input.GetAxis("Acceleration_" + playerTag);
        rotate = Input.GetAxis("Steer_" + playerTag);

        Vector3 MoveWagon = new Vector3(sideStepForceInput * sideStepPower * sideStepMultiplier, 0, (forwardForceInput * acceleration) * accelerationMultiplier);

        //When i drive Backward i need a invert Input
        Wagon_RB.transform.Rotate(0, rotate * steerPower * steerMultiplier, 0);
        Wagon_RB.AddRelativeForce(MoveWagon);
    }

    void Confuse()
    {
        if (confuseTimer < 0)
        {
            IsConfuse = false;
            confuseTimer = confuseTimerOriginal;
            SideStepPower = 1;
            SteerMultiplier = 1;
        }
        
        confuseTimer -= 1.0f * Time.deltaTime;
    }

    void InSticky()
    {
        if(stickyTimer <= 0)
        {
            inStickyPuddle = false;
            stickyTimer = stickyTimerOriginal;
            this.gameObject.GetComponent<Rigidbody>().mass -= StickyMassBoni;
        }

        stickyTimer -= 1.0f * Time.deltaTime;
    }

    void OnSlipperyWet()
    {
        if (slipperyWhenWetTimer <= 0)
        {
            onSlipperyWet = false;
            slipperyWhenWetTimer = slipperyWhenWetTimerOriginal;
            this.gameObject.GetComponent<Rigidbody>().mass -= stickyMassBoni;
        }

        slipperyWhenWetTimer -= 1.0f * Time.deltaTime;
    }
    
    void Turbo()
    {
        //Give - on MassBoni!!?
        if (turboTimer < 0)
        {
            OnTurbo = false;
            turboTimer = turboTimerOriginal;
            //AccelerationMultiplier -= 0.0f;
            this.gameObject.GetComponent<Rigidbody>().mass += TurboMassBoni;
        }

        turboTimer -= 1.0f * Time.deltaTime;
    }



    void TimerSettings()
    {
        turboTimer = turboTimerOriginal;
        confuseTimer = confuseTimerOriginal;
        stickyTimer = stickyTimerOriginal;
        slipperyWhenWetTimer = slipperyWhenWetTimerOriginal;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sticky_Puddle" && inStickyPuddle != true)
        {
            inStickyPuddle = true;
            this.gameObject.GetComponent<Rigidbody>().mass += StickyMassBoni;
        }

        else if (other.tag == "Sliery_When_Wet" && onSlipperyWet != true)
        {
            onSlipperyWet = true;
        }
    }

    
}
