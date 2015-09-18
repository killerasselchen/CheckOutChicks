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

    [SerializeField]
    private Animator animator;

    #region Movement

    [SerializeField]
    public string playerTag;

    private float acceleration = 23.0f;

    private float accelerationMultiplier = 1.0f;

    private float forwardForceInput;

    [SerializeField]
    private new Rigidbody rigidbody;

    private float rotate;
    private float sideStepForceInput;
    private float sideStepMultiplier = 1.0f;
    private float sideStepPower = 14.0f;

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
    private float confuseTimerOriginal = 8.0f;
    private float turboTimer;
    private float turboTimerOriginal = 10.0f;

    #endregion Timer

    #region PowerUp Fields and Props

    [SerializeField]
    private GameObject shield;

    private float stickyMassBoni;
    private float turboMassBoni = 0.3f;

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
            OnTurbo = true;
        }

        turboTimer = turboTimerOriginal;
    }

    private void CheckOnPowerUpEffects()
    {
        if (IsConfuse)
            Confuse();
        else if (OnTurbo)
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
            OnTurbo = false;
            turboTimer = turboTimerOriginal;
            this.rigidbody.mass += TurboMassBoni;
        }

        turboTimer -= 1.0f * Time.deltaTime;
    }

    #endregion PowerUp Fields and Props

    private void Awake()
    {
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
        CheckOnPowerUpEffects();
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
        animator.SetFloat("Forward", forwardForceInput);
        Direction.Normalize();
        Direction = Vector3.Slerp(OldDirection, Direction, SliperyFactor);

        rigidbody.transform.Rotate(0, rotate * steerPower * steerMultiplier, 0);
        rigidbody.AddRelativeForce(Direction);
    }
}