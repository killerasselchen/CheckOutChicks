using UnityEngine;
using System.Collections;

public class Power_Up_Spin : MonoBehaviour {

    private float speed = 20;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

	void Update()
    {
        Spin();
    }

    private void Spin()
    {
        this.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void GoUpAndDown()
    {
       
    }
}
