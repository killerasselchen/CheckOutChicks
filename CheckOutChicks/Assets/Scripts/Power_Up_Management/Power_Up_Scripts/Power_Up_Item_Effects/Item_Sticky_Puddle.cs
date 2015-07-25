using UnityEngine;
using System.Collections;

public class Item_Sticky_Puddle : MonoBehaviour {

    float lifeTime;
	
    void Awake()
    {
        lifeTime = 8;
    }

	// Update is called once per frame
	void Update () 
    {
        LifeTimeCheck();
	}

    void OnTriggerStay(Collider other)
    {
        other.GetComponent<Move>().inStickyPuddle = true;
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<Move>().inStickyPuddle = false;
    }

    void LifeTimeCheck()
    {
        if (lifeTime >= 0)
            lifeTime -= 1 * Time.deltaTime;

        else if(lifeTime <= 0)
            Destroy(this.gameObject);
    }
}
