using System.Collections.Generic;
using UnityEngine;

public class SlipperyWhenWetItem : MonoBehaviour
{
    [SerializeField]
    private List<Collider> collider = new List<Collider>();

    private Player constructedPlayer = new Player();

    private float lifeTime;

    //TODO: private Felder immer klein schreiben.
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
        //HACK: Funktioniert mit momentanem System nicht!
        //TODO: Besser: other.GetComponent<Player>()
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
        //HACK: Funktioniert mit momentanem System nicht!
        //TODO: Besser: other.GetComponent<Player>()
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
            //HACK: Diese Abfrage ist unnötig.
            if (other.GetComponentInParent<Player>() != constructedPlayer)
            {
                //UNDONE: MyPoints -= 15 == MyPoints = MyPoints - 15.
                // MyPoints = value macht hier aber:
                // MyPoints = MyPoints + (MyPoints - 15) * 2
                // Was am Ende
                // MyPoints = MyPoints * 3 - 30
                // ergibt.
                //TODO: Ändern von MyPoints -= 15 zu MyPoints = -15 ODER Player.AddPoints(-15)
                //Player.AddPoints wäre dann:
                /*
                public void AddPoints(int points)
                {
                    if (onPointBoost)
                        myPoints += points * 2;
                    else
                        myPoints += points;
                }
                */
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
        //TODO: Schöner wäre vmtl. if (lifeTime > 0) {} else {}
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