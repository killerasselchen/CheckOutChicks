using UnityEngine;
using System.Collections;

public class Ware : MonoBehaviour
{
    private Vector3 origin;
    [SerializeField]
    private float sphereCastRadius = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("Colliding with {0}", collision.gameObject.tag);
        if(collision.gameObject.tag == "Floor")
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
                //Hier gehts weiter. Der Player wird so, natürlich, nicht als solcher erkannt, sondern ist nur ein Eintrag namens Player
            }
            
        }
    }
}