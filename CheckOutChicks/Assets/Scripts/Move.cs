//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Rigidbody Wagon_RB;

    public bool confuse = false;
    public bool inStickyPuddle = false;

    private float forwardForcePower = 23;
    private float forwarPowerUpMultiplier = 1;
    private float sideStepPower = 1.0f;
    private float sidePowerUpMultiplier = 1;
    private float rotationPower = 2;
    private float rotationPowerUpMultiplier = 1;

    private string playerNr;

    public float sideStepForceInput;

	void Awake () 
    {
        Wagon_RB = GetComponent<Rigidbody>();
        playerNr = gameObject.tag;
	}
	
	void FixedUpdate () 
    {
        isConfuse();
        inSticky();
        Movement();
	}

    void Movement()
    {
        sideStepForceInput = Input.GetAxis("SideStep_P_1");
        float forwardForceInput = Input.GetAxis("Vertical_" + playerNr);
        float rotationInput = Input.GetAxis("Horizontal_" + playerNr);
        Vector3 MoveWagon = new Vector3(sideStepForceInput , 0, forwardForceInput * forwardForcePower);

        //When i drive Backward i need a invert Input
        Wagon_RB.transform.Rotate(0, rotationInput * rotationPower * rotationPowerUpMultiplier, 0);
        //Wagon_RB.transform.Translate(new Vector3(sideStepForceInput * sideStepPower, 0, 0));
        Wagon_RB.AddRelativeForce(MoveWagon);
    }

    void isConfuse()
    {
        if (confuse)
        {
            sidePowerUpMultiplier = -1;
            rotationPowerUpMultiplier = -1;
        }
        else if (!confuse)
        {
            sidePowerUpMultiplier = 1;
            rotationPowerUpMultiplier = 1;
        }
    }

    void inSticky()
    {
        if (inStickyPuddle)
        {
            forwarPowerUpMultiplier = 0.3f;
        }
        else if(!inStickyPuddle)
        {
            forwarPowerUpMultiplier = 1.0f;
        }
    }
}
