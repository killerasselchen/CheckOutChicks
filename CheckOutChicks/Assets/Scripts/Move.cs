//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Rigidbody Wagon_RB;

    private float forwardForceMultiplier = 23;
    private float sideStepMultiplier = 2;
    private float rotationMultiplier = 2;

    private string playerNr;

    public bool confuse = false;
    public static float confuseFloat = 1;


	void Awake () 
    {
        Wagon_RB = GetComponent<Rigidbody>();
        playerNr = gameObject.tag;
	}
	
	void FixedUpdate () 
    {
        isConfuse();
        Movement();
	}

    void Movement()
    {
        float sideStepForce = Input.GetAxis("SideStep_" + playerNr) * confuseFloat;
        float forwardForce = Input.GetAxis("Vertical_" + playerNr);
        float rotationPower = Input.GetAxis("Horizontal_" + playerNr) * confuseFloat;
        Vector3 MoveWagon = new Vector3(sideStepForce * sideStepMultiplier, 0, forwardForce * forwardForceMultiplier);
        //Vector3 MoveWagon = new Vector3(0, 0, forwardForce * forwardForceMultiplier);

        //When i drive Backward i need a invert Input
        Wagon_RB.transform.Rotate(0, rotationPower * rotationMultiplier, 0);

        Wagon_RB.AddRelativeForce(MoveWagon);
    }

    void isConfuse()
    {
        if (confuse == true)
            confuseFloat = -1;
        else if (confuse == false)
            confuseFloat = 1;
    }

}
