//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class Arrow : Menu
{
    public static Vector3 target;

    private void FixedUpdate()
    {
        if (target == null)
            this.gameObject.GetComponentInChildren<MeshRenderer>().gameObject.SetActive(false);
        else
        {
            this.gameObject.GetComponentInChildren<MeshRenderer>().gameObject.SetActive(true);
            this.transform.LookAt(target, Vector3.up);
        }
    }
}