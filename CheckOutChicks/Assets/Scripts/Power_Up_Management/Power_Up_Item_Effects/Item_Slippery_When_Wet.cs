using UnityEngine;
using System.Collections;

public class Item_Slippery_When_Wet : MonoBehaviour {

    private float lifeTime;

    private Player constructedPlayer = new Player();

    public Player ConstructedPlayer
    {
        get { return constructedPlayer; }
        set { constructedPlayer = value; }
    }

    void Awake()
    {
        lifeTime = 8;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimeCheck();
    }

    void LifeTimeCheck()
    {
        if (lifeTime >= 0)
            lifeTime -= 1 * Time.deltaTime;

        else if (lifeTime <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //hier weiter machen
            if (other.GetComponentInParent<Player>() != constructedPlayer)
            {
                constructedPlayer.MyPoints += 10.0f * Time.deltaTime;
            }
        }
    }

    public void SetConstructedPlayer(Player constructedPlayer)
    {
        ConstructedPlayer = constructedPlayer;
    }
}