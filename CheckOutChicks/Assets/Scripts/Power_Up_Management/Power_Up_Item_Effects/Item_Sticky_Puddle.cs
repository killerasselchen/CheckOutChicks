using UnityEngine;
using System.Collections;

public class Item_Sticky_Puddle : MonoBehaviour {

    private Player constructedPlayer = new Player();

    public Player ConstructedPlayer
    {
        get { return constructedPlayer; }
        set { constructedPlayer = value; }
    }

    private float trapCount = 0;
    private float trapBorder = 2;

    public float lifeTime;
	
    void Awake()
    {
        Debug.Log("ConstPlayer: " + constructedPlayer);

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
            if(trapCount <= trapBorder)
            {
                constructedPlayer.MyPoints += 10.0f * Time.deltaTime;
                trapCount += 1.0f * Time.deltaTime;
            }

            else if (trapCount >= trapBorder)
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
