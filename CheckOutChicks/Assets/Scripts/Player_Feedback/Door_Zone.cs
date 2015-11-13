using UnityEngine;

public class Door_Zone : MonoBehaviour
{
    private Animator doorAnimator;

    [SerializeField]
    private GameObject doorObject;

    private bool isPlayerIn;

    [SerializeField]
    private AudioSource Sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player_One" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", true);
            Sound.Play();
        }
        if (other.gameObject.tag == "Player_Two" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", true);
            Sound.Play();
        }
        if (other.gameObject.tag == "Player_Three" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", true);
            Sound.Play();
        }
        if (other.gameObject.tag == "Player_Four" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", true);
            Sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player_One" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", false);
            Sound.Play();
        }
        if (other.gameObject.tag == "Player_Two" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", false);
            Sound.Play();
        }
        if (other.gameObject.tag == "Player_Three" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", false);
            Sound.Play();
        }
        if (other.gameObject.tag == "Player_Four" || other.gameObject.tag == "Wagon")
        {
            doorAnimator.SetBool("infrontOfDoor", false);
            Sound.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player_One" || other.gameObject.tag == "Wagon")
        {
            isPlayerIn = true;
        }
        if (other.gameObject.tag == "Player_Two" || other.gameObject.tag == "Wagon")
        {
            isPlayerIn = true;
        }
        if (other.gameObject.tag == "Player_Three" || other.gameObject.tag == "Wagon")
        {
            isPlayerIn = true;
        }
        if (other.gameObject.tag == "Player_Four" || other.gameObject.tag == "Wagon")
        {
            isPlayerIn = true;
        }
    }

    private void Start()
    {
        doorAnimator = doorObject.GetComponent<Animator>();
        isPlayerIn = false;
    }
}