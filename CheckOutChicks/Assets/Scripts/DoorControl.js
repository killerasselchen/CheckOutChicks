#pragma strict
//Build by Christoph
//Adjusted by Sharon
//Edit by Timo Fabricius on 28.10.2015

var doorObject : GameObject;
private var doorAnimator : Animator;

function Start () {
	doorAnimator = doorObject.GetComponent(Animator);
}

function Update () {

}

function OnTriggerStay( other : Collider)
{
    if(other.gameObject.tag == "Player_One" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
	}
    if(other.gameObject.tag == "Player_Two" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
	}
    if(other.gameObject.tag == "Player_Three" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
	}
    if(other.gameObject.tag == "Player_Four" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
    }
}

function OnTriggerExit( other : Collider)
{
    if(other.gameObject.tag == "Player_One" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
    if(other.gameObject.tag == "Player_Two" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
    if(other.gameObject.tag == "Player_Three" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
    if(other.gameObject.tag == "Player_Four" || other.gameObject.tag == "Wagon")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
}