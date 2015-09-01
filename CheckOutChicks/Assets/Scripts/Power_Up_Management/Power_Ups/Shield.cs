using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : MonoBehaviour 
{
    [SerializeField]
    private List<Collider> collider = new List<Collider>();

    private Rigidbody temp;

    void OnDisable()
    {
        foreach (var c in collider)
        {
            c.GetComponent<Rigidbody>().isKinematic = false;
        }
        collider.Clear();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Rigidbody temp = other.GetComponent<Rigidbody>();
    //    if (temp == null) return;

    //    if (other.tag == "Interieur")
    //    {
    //        other.GetComponent<Rigidbody>().isKinematic = true;
    //        collider.Add(other);
    //    }
    //}

    void OnTriggerStay(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();
        if (temp == null) return;

        if (other.tag == "Interieur")
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            //collider.Add(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();
        if (temp == null) return;

        if (other.tag == "Interieur")
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            collider.Remove(other);
        }
    }
}
