using UnityEngine;
using System.Collections;

public class FeedbackTrigger : MonoBehaviour 
{
    //[SerializeField]
    //private GameObject collisionImage;

    [SerializeField]
    private AudioSource collisionSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wagon" && !collisionSound.isPlaying)
        {
            collisionSound.Play();
        }
    }
}
