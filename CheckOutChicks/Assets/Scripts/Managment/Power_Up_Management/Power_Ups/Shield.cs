//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private List<Collider> collider = new List<Collider>();

    private Rigidbody temp;

    private void OnDisable()
    {
        foreach (var c in collider)
        {
            c.GetComponent<Rigidbody>().isKinematic = false;
        }
        collider.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();
        if (temp == null) return;

        if (other.tag == "Interieur" && !collider.Contains(other))
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            collider.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();
        if (temp == null) return;

        if (other.tag == "Interieur")
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            collider.Remove(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();
        if (temp == null) return;

        if (other.tag == "Interieur")
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}