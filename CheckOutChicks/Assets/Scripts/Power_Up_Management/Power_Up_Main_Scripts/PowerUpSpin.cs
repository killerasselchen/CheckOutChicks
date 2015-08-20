using UnityEngine;

public class PowerUpSpin : MonoBehaviour
{
    private float speed = 20;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Update()
    {
        Spin();
    }

    private void Spin()
    {
        this.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    //private void GoUpAndDown()
    //{
    //}
}