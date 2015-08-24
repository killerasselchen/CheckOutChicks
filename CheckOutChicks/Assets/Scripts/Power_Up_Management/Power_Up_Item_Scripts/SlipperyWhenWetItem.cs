using UnityEngine;

public class SlipperyWhenWetItem : MonoBehaviour
{
    private float lifeTime;

    private Player constructedPlayer = new Player();

    public Player ConstructedPlayer
    {
        get { return constructedPlayer; }
        set { constructedPlayer = value; }
    }

    private void Awake()
    {
        lifeTime = 8;
    }

    // Update is called once per frame
    private void Update()
    {
        LifeTimeCheck();
    }

    public void SetConstructedPlayer(Player constructedPlayer)
    {
        ConstructedPlayer = constructedPlayer;
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
        if (other.GetComponentInParent<Player>() != constructedPlayer)
        {
            //hier weiter machen -- kann ja eh nicht const player sein
            if (other.GetComponentInParent<Player>() != constructedPlayer)
            {
                constructedPlayer.MyPoints += 10.0f * Time.deltaTime;
            }
        }


        
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();

        if (temp == null) return;

        if (other.GetComponent<Player>() != constructedPlayer)
            constructedPlayer.MyPoints += 20.0f;
    }
}