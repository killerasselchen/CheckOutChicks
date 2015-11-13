//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class AccidentCheck : MonoBehaviour
{
    //[SerializeField]
    //private AudioSource shoppingCardLittleCrashSound;

    //[SerializeField]
    //private AudioSource shoppingCardHeavyCrashSound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_Body")
        {
            this.gameObject.GetComponentInParent<Player>().AddPoints(25);
            other.gameObject.GetComponentInParent<Player>().AddPoints(-15);
        }
    }
}