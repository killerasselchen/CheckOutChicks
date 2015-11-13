//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class StickyPuddleItem : MonoBehaviour
{
    //[SerializeField]
    //private AudioClip honeyGlasFalling;

    [SerializeField]
    private GameObject parent;

    private Player constructedPlayer = new Player(); 
    private float lifeTime;

    private float trapBorderOne = 0;

    private float trapBorderTwo = 2;

    public Player ConstructedPlayer
    {
        get { return constructedPlayer; }
        set { constructedPlayer = value; }
    }

    public void SetConstructedPlayer(Player constructedPlayer)
    {
        ConstructedPlayer = constructedPlayer;
    }

    private void Awake()
    {
        //constructedPlayer = new Player();
        lifeTime = 12;
    }

    private void LifeTimeCheck()
    {
        if (lifeTime >= 0)
            lifeTime -= 1 * Time.deltaTime;
        else if (lifeTime <= 0)
            Destroy(parent);
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();

        if (temp == null || other.gameObject.layer != 14) return;
        if (other.GetComponent<Player>() != constructedPlayer)
        {
            if (trapBorderOne <= trapBorderTwo)
            {
                constructedPlayer.AddPoints(10 * Time.deltaTime);
                trapBorderOne += 1.0f * Time.deltaTime;
            }
            else if (trapBorderOne >= trapBorderTwo)
            {
                constructedPlayer.AddPoints(20 * Time.deltaTime);
            }
        }
        temp.velocity = Vector3.ClampMagnitude(temp.velocity, 3);
    }

    private void FixedUpdate()
    {
        LifeTimeCheck();
    }
}