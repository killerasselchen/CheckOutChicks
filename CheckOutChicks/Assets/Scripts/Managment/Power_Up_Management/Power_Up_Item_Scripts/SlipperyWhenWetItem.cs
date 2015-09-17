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
        Rigidbody temp = other.GetComponent<Rigidbody>();

        if (temp == null || other.gameObject.layer != 14) return;
        {
            if (other.GetComponent<Player>() != constructedPlayer)
                constructedPlayer.AddPoints(20);

            other.GetComponent<Move>().SliperyFactor = TempSliperyFactor;
            collider.Add(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();

        if (temp == null || other.gameObject.layer != 14) return;
        {
            other.GetComponent<Move>().SliperyFactor = 1;
            collider.Remove(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();

        if (temp == null || other.gameObject.layer != 14) return;
        if (other.GetComponent<Player>() != constructedPlayer)
        {
            constructedPlayer.AddPoints(10 * Time.deltaTime);
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

    private void Update()
    {
        LifeTimeCheck();
    }
}