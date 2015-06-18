//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    //*****
    public Rigidbody Wagon_RB;

    [SerializeField]
    private float forwardForceMultiplier;
    private float sideStepMultiplier;
    private float rotationMultiplier;
    private string playerNr;

	void Awake () 
    {
        Wagon_RB = GetComponent<Rigidbody>();
        playerNr = gameObject.tag;
	}
	
	void FixedUpdate () 
    {
        //****
        float sideStepForce = Input.GetAxis("SideStep_" + playerNr);
        float forwardForce = Input.GetAxis("Vertical_" + playerNr);
        float rotationPower = Input.GetAxis("Horizontal_" + playerNr);
        //****
        Vector3 MoveWagon = new Vector3(sideStepForce * sideStepMultiplier, 0, forwardForce * forwardForceMultiplier);

        Wagon_RB.transform.Rotate(0, rotationPower * rotationMultiplier, 0);
        Wagon_RB.AddRelativeForce(MoveWagon);
        
	}
}
