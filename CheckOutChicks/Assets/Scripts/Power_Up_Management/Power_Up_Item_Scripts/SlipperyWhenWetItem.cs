using System.Collections.Generic;
using UnityEngine;

public class SlipperyWhenWetItem : MonoBehaviour
{
    [SerializeField]
    private List<Collider> collider = new List<Collider>();

    private Player constructedPlayer = new Player();

    private float lifeTime;

    [SerializeField]
    private float TempSliperyFactor;

    public Player ConstructedPlayer
    {
        get { return constructedPlayer; }
        set { constructedPlayer = value; }
    }

    public void OnDestroy()
    {
        foreach (var c in collider)
        {
            c.GetComponent<Move>().SliperyFactor = 1;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Temp noch ersetzen durch abfrage des Tag??
        //Rigidbody temp = other.GetComponent<Rigidbody>();

        //if (temp == null) return;
        if (other.tag == "P_1" || other.tag == "P_2" || other.tag == "P_3" || other.tag == "P_4")
        {
            if (other.GetComponent<Player>() != constructedPlayer)
                constructedPlayer.MyPoints += 20.0f;

            other.GetComponent<Move>().SliperyFactor = TempSliperyFactor;
            collider.Add(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "P_1" || other.tag == "P_2" || other.tag == "P_3" || other.tag == "P_4")
        {
            other.GetComponent<Move>().SliperyFactor = 1;
            collider.Remove(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();

        if (temp == null) return;
        if (other.GetComponentInParent<Player>() != constructedPlayer)
        {
            //hier weiter machen -- kann ja eh nicht const player sein
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

    // Update is called once per frame
    private void Update()
    {
        LifeTimeCheck();
    }
}