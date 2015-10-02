//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class AccidentCheck : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_Body")
        {
            Debug.Log("hit player");
            this.gameObject.GetComponentInParent<Player>().AddPoints(25);
            other.gameObject.GetComponentInParent<Player>().AddPoints(-15);
        }
    }
}