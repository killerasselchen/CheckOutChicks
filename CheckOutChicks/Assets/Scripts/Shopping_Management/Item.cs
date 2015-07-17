using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour
{
    public float lifetime = 0;

    public float Lifetime
    {
        get { return lifetime; }
        set { lifetime = value; }
    }

    //public delegate void DeactivateEvent(Item item);
    //public DeactivateEvent OnItemDeactivation;

    void OnEnable()
    {
        LifeTimer();
    }

    void OnDisable()
    {
        Lifetime = 0;
    }

    private void LifeTimer()
    {
        Lifetime += 1.0f * Time.deltaTime;
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
