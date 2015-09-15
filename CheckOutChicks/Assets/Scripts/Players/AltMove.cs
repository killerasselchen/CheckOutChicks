using UnityEngine;
using System.Collections;

public class AltMove : MonoBehaviour
{

    [SerializeField]
    private Rigidbody RB;
    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private float Velo;

    float z;

    private void Start()
    {
        Velo = RB.velocity.z;
        RB.AddForce(Vector3.back, ForceMode.Impulse);
    }

    //public void Update()
    //{
    //    z = Input.GetAxis("Acceleration_Player_One");

    //    //transform.localPosition = new Vector3(0, 0, z);
    //}

    public void FixedUpdate()
    {
        RB.AddForce(Vector3.back, ForceMode.Impulse);
        Animator.SetFloat("Forward", RB.velocity.magnitude);
    }
}
