//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class Move : MonoBehaviour
{
    public bool InStickyPuddle = false;
    public bool IsConfuse = false;
    public bool OnSlipperyWet = false;
    public bool OnTurbo = false;

    #region Movement

    private float acceleration = 23.0f;

    private float accelerationMultiplier = 1.0f;

    private float forwardForceInput;

    private string playerTag;

    [SerializeField]
    private new Rigidbody rigidbody;

    private float rotate;
    private float sideStepForceInput;
    private float sideStepMultiplier = 1.0f;
    private float sideStepPower = 12.0f;

    [SerializeField]
    private float sliperyFactor = 1;

    private float steerMultiplier = 1.0f;
    private float steerPower = 2.0f;

    public float AccelerationMultiplier
    {
        get { return accelerationMultiplier; }
        set { accelerationMultiplier = value; }
    }

    public Vector3 Direction { get; set; }
    public Vector3 OldDirection { get; set; }
    public float OldVelocity { get; set; }

    public float SideStepPower
    {
        get { return sideStepMultiplier; }
        set { sideStepMultiplier = value; }
    }

    public float SliperyFactor
    {
        get { return sliperyFactor; }
        set { sliperyFactor = value; }
    }

    public float SteerMultiplier
    {
        get { return steerMultiplier; }
        set { steerMultiplier = value; }
    }

    public float Velocity { get; set; }

    #endregion Movement

    #region Timer

    //->Timer needs Props for MenuChanges
    private float confuseTimer;
    private float confuseTimerOriginal = 5.0f;
    private float slipperyWhenWetTimer;
    private float slipperyWhenWetTimerOriginal = 7.0f;
    private float turboTimer;
    private float turboTimerOriginal = 10.0f;

    #endregion Timer

    #region PowerUp Fields and Props

    [SerializeField]
    private GameObject shield;

    private float stickyMassBoni;
    private float turboMassBoni = 0.3f;

    private PowerUpUI ui_Power_Up;

    private float wagonExtraMass = 0;

    public float StickyMassBoni
    {
        get { return stickyMassBoni; }
        set { stickyMassBoni = value; }
    }

    public float TurboMassBoni
    {
        get { return turboMassBoni; }
        set { turboMassBoni = value; }
    }

    public void ActivateTurbo()
    {
        if (OnTurbo == false)
        {
            this.rigidbody.mass -= TurboMassBoni;
            shield.SetActive(true);
            //Für einen anderen Lösungsansatz gedacht
            //this.gameObject.layer = 13;
            OnTurbo = true;
        }

        turboTimer = turboTimerOriginal;
    }

    private void CheckOnPowerUpEffects()
    {
        //evtl. Scripte instanzieren auf die jeweiligen Player
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

    private void TimerSettings()
    {
        turboTimer = turboTimerOriginal;
        confuseTimer = confuseTimerOriginal;
    }

    private void Turbo()
    {
        if (turboTimer <= 0)
        {
            shield.SetActive(false);

            //Für einen anderen Lösungsansatz gedacht
            //this.gameObject.layer = 14;
            OnTurbo = false;
            turboTimer = turboTimerOriginal;
            this.rigidbody.mass += TurboMassBoni;
        }

        turboTimer -= 1.0f * Time.deltaTime;
    }

    #endregion PowerUp Fields and Props

    private void Awake()
    {
        //reinziehen
        playerTag = gameObject.tag;
        ui_Power_Up = GameObject.Find("UI_" + playerTag).GetComponent<PowerUpUI>();
        TimerSettings();
    }

    private void CheckInput()
    {
        sideStepForceInput = Input.GetAxis("SideStep_" + playerTag);
        forwardForceInput = Input.GetAxis("Acceleration_" + playerTag);
        rotate = Input.GetAxis("Steer_" + playerTag);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        CheckInput();
        if (OnTurbo)
            Turbo();

        OldDirection = Direction;
        OldVelocity = Velocity;

        Direction = new Vector3(sideStepForceInput * sideStepPower * sideStepMultiplier, 0, (forwardForceInput * acceleration) * accelerationMultiplier);
        Velocity = Direction.magnitude;
        Direction.Normalize();
        Direction = Vector3.Slerp(OldDirection, Direction, SliperyFactor);

        //When i drive Backward i need a invert Input
        rigidbody.transform.Rotate(0, rotate * steerPower * steerMultiplier, 0);
        rigidbody.AddRelativeForce(Direction);
    }

    private void Update()
    {
        CheckOnPowerUpEffects();
    }
}