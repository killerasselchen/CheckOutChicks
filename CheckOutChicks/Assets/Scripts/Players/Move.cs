//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class Move : MonoBehaviour
{
    private string playerTag;

    [SerializeField]
    private Rigidbody wagon_RB;

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

    private PowerUpUI ui_Power_Up;

    private void Awake()
    {
        //reinziehen
        playerTag = gameObject.tag;
        ui_Power_Up = GameObject.Find("UI_" + playerTag).GetComponent<PowerUpUI>();
        TimerSettings();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        CheckOnPowerUpEffects();
    }

    private void CheckInput()
    {
        sideStepForceInput = Input.GetAxis("SideStep_" + playerTag);
        forwardForceInput = Input.GetAxis("Acceleration_" + playerTag);
        rotate = Input.GetAxis("Steer_" + playerTag);
    }

    private void Movement()
    {
        CheckInput();

        Vector3 MoveWagon = new Vector3(sideStepForceInput * sideStepPower * sideStepMultiplier, 0, (forwardForceInput * acceleration) * accelerationMultiplier);
        //When i drive Backward i need a invert Input
        wagon_RB.transform.Rotate(0, rotate * steerPower * steerMultiplier, 0);
        wagon_RB.AddRelativeForce(MoveWagon);
    }

    private void CheckOnPowerUpEffects()
    {
        //Scripte instanzieren auf die jeweiligen Player
        if (IsConfuse)
            Confuse();

        if (OnTurbo)
            Turbo();
    }

    private void Confuse()
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

    //void OnSlipperyWet()
    //{
    //    if (slipperyWhenWetTimer <= 0)
    //    {
    //        onSlipperyWet = false;
    //        slipperyWhenWetTimer = slipperyWhenWetTimerOriginal;
    //        //this.gameObject.GetComponent<Rigidbody>().mass -= stickyMassBoni;
    //    }

    //    slipperyWhenWetTimer -= 1.0f * Time.deltaTime;
    //}

    private void Turbo()
    {
        //Make is a nother way
        if (turboTimer <= 0)
        {
            OnTurbo = false;
            turboTimer = turboTimerOriginal;
            this.gameObject.GetComponent<Rigidbody>().mass += TurboMassBoni;
        }

        turboTimer -= 1.0f * Time.deltaTime;
    }

    private void TimerSettings()
    {
        turboTimer = turboTimerOriginal;
        confuseTimer = confuseTimerOriginal;
    }
}