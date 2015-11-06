using UnityEngine;
using System.Collections;

public class FeedbackTrigger : MonoBehaviour 
{
    //[SerializeField]
    //private GameObject collisionImage;

    [SerializeField]
    private AudioSource collisionSound;

    //void Start()
    //{
    //    //delete later
    //    if (collisionSound == null)
    //        Debug.Log("CollisionSoundfile is missing or not usable on: " + this.gameObject.name);
    //}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wagon" && collisionSound.isPlaying == false)
        {
            //collisionSound.PlayOneShot(collisionSound.clip);
            collisionSound.Play();
            Debug.Log("hit with " + this.gameObject.name);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {
        
    }
}
