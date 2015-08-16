//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Item_Sticky_Puddle : MonoBehaviour {

    private float lifeTime;

    private Player constructedPlayer = new Player();

    public Player ConstructedPlayer
    {
        get { return constructedPlayer; }
        set { constructedPlayer = value; }
    }

    //When Someone else drive into the StickyPuddle, the constructedPlayer became Points per Sec. The TrapLevels are Timeborders in Sec. and increase the Points per Sec.
    private float trapLevelOne = 0;
    private float trapLevelTwo = 2;

    void Awake()
    {
        lifeTime = 8;
    }

	// Update is called once per frame
	void Update () 
    {
        LifeTimeCheck();
	}

    void LifeTimeCheck()
    {
        if (lifeTime >= 0)
            lifeTime -= 1 * Time.deltaTime;

        else if(lifeTime <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.GetComponentInParent<Player>() != constructedPlayer)
        {
            if (trapLevelOne <= trapLevelTwo)
            {
                constructedPlayer.MyPoints += 10.0f * Time.deltaTime;
                trapLevelOne += 1.0f * Time.deltaTime;
            }

            else if (trapLevelOne >= trapLevelTwo)
            {
                constructedPlayer.MyPoints += 20.0f * Time.deltaTime;
            }
        }
    }

    
    public void SetConstructedPlayer(Player constructedPlayer)
    {
        ConstructedPlayer = constructedPlayer;
    }
}
