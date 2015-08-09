//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour
{
    public float timeBoni = 0;

    public float TimeBoni
    {
        get { return timeBoni; }
        set { timeBoni = value; }
    }

    void Update()
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
