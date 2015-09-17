#pragma strict
//Build by Christoph
//Adjusted by Sharon

var doorObject : GameObject;
private var doorAnimator : Animator;

function Start () {
	doorAnimator = doorObject.GetComponent(Animator);
}

function Update () {

}

function OnTriggerEnter( other : Collider)
{
	if(other.gameObject.tag == "Player_One")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
	}
	if(other.gameObject.tag == "Player_Two")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
	}
	if(other.gameObject.tag == "Player_Three")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
	}
	if(other.gameObject.tag == "Player_Four")
	{
		doorAnimator.SetBool("infrontOfDoor", true);
	}
}

function OnTriggerExit( other : Collider)
{
	if(other.gameObject.tag == "Player_One")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
	if(other.gameObject.tag == "Player_Two")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
	if(other.gameObject.tag == "Player_Three")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
	if(other.gameObject.tag == "Player_Four")
	{
		doorAnimator.SetBool("infrontOfDoor", false);
	}
}