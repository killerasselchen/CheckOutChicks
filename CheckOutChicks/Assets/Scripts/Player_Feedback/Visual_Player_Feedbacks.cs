//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Visual_Player_Feedbacks : MonoBehaviour
{
    public Player MyTarget;
    public Vector3 FeedbackPosition;
    private float lifetime;

    public void Start()
    {
        lifetime = 2f;
        transform.LookAt(MyTarget.transform.position);
    }

    public void FixedUpdate()
    {
        lifetime -= 1 * Time.deltaTime;

        if (lifetime <= 1)
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;

        if (lifetime <= 0)
            Destroy(this.gameObject);
    }
}
