//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class Item : MonoBehaviour
{
    private float spinSpeed = 50;
    [SerializeField]
    private float hoppingRange = 0;
    private float startHeight;
    private bool goUp = true;
    private float timeBoni = 25;

    ////For Changes over the GameManagment to an spezial event/time. For next Update
    //public float Speed
    //{
    //    get { return speed; }
    //    set { speed = value; }
    //}

    private void Awake()
    {
        startHeight = transform.position.y;
    }

    public float TimeBoni
    {
        get { return timeBoni; }
        set { timeBoni = value; }
    }

    private void LifeTimer()
    {
        if (TimeBoni >= 0)
            TimeBoni -= 1.0f * Time.deltaTime;
        else
            TimeBoni = 0;
    }

    private void Spin()
    {
        this.transform.Rotate(0, spinSpeed * Time.unscaledDeltaTime, 0);
    }

    private void Update()
    {
        LifeTimer();
        Spin();
    }
}