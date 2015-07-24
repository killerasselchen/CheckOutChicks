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

    //public delegate void DeactivateEvent(Item item);
    //public DeactivateEvent OnItemDeactivation;

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

    //void Deactivate()
    //{
    //    //Shopping_Manager.currentItems--;
    //    if (OnItemDeactivation == null)
    //    {
    //        throw new MissingMethodException("OnItemDeactivation ist null");
    //        OnItemDeactivation(this);
    //        this.gameObject.SetActive(false);
    //    }

    //}
}
