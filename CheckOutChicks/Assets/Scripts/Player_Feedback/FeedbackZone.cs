using UnityEngine;
using System.Collections;

public class FeedbackZone : MonoBehaviour
{

    [SerializeField]
    private AudioSource Sound;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wagon" && !Sound.isPlaying)
        {
            Sound.Play();
        }
    }
}
