//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class Item : MonoBehaviour
{
    private float timeBoni = 25;

    public float TimeBoni
    {
        get { return timeBoni; }
        set { timeBoni = value; }
    }

    private void Update()
    {
        LifeTimer();
    }

    private void LifeTimer()
    {
        if (TimeBoni >= 0)
            TimeBoni -= 1.0f * Time.deltaTime;
        else
            TimeBoni = 0;
    }
}