using UnityEngine;
using System.Collections;

public class SpinTheCams : MonoBehaviour
{
    private float speed = 20f;

    //For Changes over the GameManagment to an spezial event/time.
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Spin()
    {
        this.transform.Rotate(0, speed * Time.unscaledDeltaTime, 0, Space.World);
    }

    private void Update()
    {
        Spin();
    }
}