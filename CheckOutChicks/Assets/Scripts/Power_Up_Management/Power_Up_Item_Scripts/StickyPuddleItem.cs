//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class StickyPuddleItem : MonoBehaviour
{
    private Player constructedPlayer = new Player();
    private float lifeTime;

    //When Someone else drive into the StickyPuddle, the constructedPlayer became Points per Sec. The TrapLevels are Timeborders in Sec. and increase the Points per Sec.
    private float trapLevelOne = 0;

    private float trapLevelTwo = 2;

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
        lifeTime = 8;
    }

    private void LifeTimeCheck()
    {
        if (lifeTime >= 0)
            lifeTime -= 1 * Time.deltaTime;
        else if (lifeTime <= 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();

        if (temp == null) return;
        if (other.GetComponent<Player>() != constructedPlayer)
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
        //ggf noch Lerp von der Eintrittsgeschwindigkeit
        temp.velocity = Vector3.ClampMagnitude(temp.velocity, 3);
    }

    // Update is called once per frame
    private void Update()
    {
        LifeTimeCheck();
    }
}