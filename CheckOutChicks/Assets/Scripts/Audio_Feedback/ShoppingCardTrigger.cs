using UnityEngine;
using System.Collections;

public class ShoppingCardTrigger : MonoBehaviour {

    [SerializeField]
    private AudioSource collisionSound;

    void Start()
    {
        //delete later
        if (collisionSound == null)
            Debug.Log("CollisionSoundfile is missing or not usable on: " + this.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interieur" && !collisionSound.isPlaying)
            collisionSound.Play();
        //else if(other.tag == ")

    }

    void OnTriggerExit(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {

    }
}
