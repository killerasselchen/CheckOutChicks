using UnityEngine;
using System.Collections;

public class Power_Up : MonoBehaviour {

	void Start () 
    {

	}
	
	void Update () 
    {
	
	}

    //i is hard code... change it!!
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < GameManager.playerQuantity; i++)
        {
            if (other.tag == "P_" + (i + 1))
            {
                this.gameObject.SetActive(false);
                GameManager.currentMapPowerUps--;
            }
        }
    }

    void ChoseItem()
    {

    }
}
