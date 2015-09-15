using UnityEngine;

public class PowerUpSpin : MonoBehaviour
{
    private float speed = 20;

    //For Changes over the GameManagment to an spezial event/time.
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Spin()
    {
        this.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void Update()
    {
        Spin();
    }

    //private void GoUpAndDown()
    //{
    //}
}