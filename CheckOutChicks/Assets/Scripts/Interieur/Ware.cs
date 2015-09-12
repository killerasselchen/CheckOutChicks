using UnityEngine;
using System.Collections;

public class Ware : MonoBehaviour
{
    private Vector3 origin;
    [SerializeField]
    private float sphereCastRadius = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Debug.Log("onFloor");
            foreach (var contact in collision.contacts)
	        {
		        origin += contact.point;
	        }

            origin = origin / collision.contacts.Length;
            Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14);

            //for (int i = 0; i < Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14).Length; i++)
            //{
            //    Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14)[0].
            //}
            foreach (var Player in Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14))
            {
                //UNDONE: MyPoints -= 15 == MyPoints = MyPoints - 15.
                // MyPoints = value macht hier aber:
                // MyPoints = MyPoints + (MyPoints - 15) * 2
                // Was am Ende
                // MyPoints = MyPoints * 3 - 30
                // ergibt.
                //TODO: Ändern von MyPoints -= 15 zu MyPoints = -15 ODER Player.AddPoints(-15)
                //Player.AddPoints wäre dann:
                /*
                public void AddPoints(int points)
                {
                    if (onPointBoost)
                        myPoints += points * 2;
                    else
                        myPoints += points;
                }
                */
                //Physics.SphereCastAll(origin, sphereCastRadius, Vector3.zero, sphereCastRadius, 14);
                Player.collider.gameObject.GetComponent<Player>().MyPoints -= 15;
                Debug.Log("loser");
                //Hier gehts weiter. Der Player wird so, natürlich, nicht als solcher erkannt, sondern ist nur ein Eintrag namens Player
            }
            
        }
    }
}