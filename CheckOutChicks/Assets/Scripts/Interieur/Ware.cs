//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class Ware : MonoBehaviour
{
    private Vector3 origin;

    [SerializeField]
    private float sphereCastRadius = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("onFloor");
            foreach (var contact in collision.contacts)
            {
                origin += contact.point;
            }

            origin = origin / collision.contacts.Length;
            //Physics.SphereCastAll(origin, sphereCastRadius, Vector3.forward, sphereCastRadius, 14);

            //for (int i = 0; i < Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14).Length; i++)
            //{
            //    Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14)[0].
            //}
            foreach (var Player in Physics.OverlapSphere(transform.position, sphereCastRadius, 14))
            {
                //Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14);
                Player.gameObject.GetComponent<Player>().AddPoints(-15);
            }
        }
    }
}