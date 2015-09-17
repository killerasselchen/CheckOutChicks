//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class SupermarketTwoCamMovment : MonoBehaviour
{
    private float reach;
    private float rotationSpeed;
    private float startRotation;

    [SerializeField]
    private float tempRotation;

    private bool turnRight = true;

    public void Awake()
    {
        startRotation = this.transform.rotation.y;
        reach = 10;
        rotationSpeed = 1;
        tempRotation = startRotation;
    }

    public void FixedUpdate()
    {
        Spin();
    }

    public void Spin()
    {
        if (tempRotation <= startRotation + reach)
        {
            tempRotation += rotationSpeed * Time.deltaTime;
            transform.rotation = new Quaternion(0, tempRotation, 0, 0);
            if (tempRotation >= startRotation + reach)
                turnRight = false;
        }
        else
        {
            tempRotation -= rotationSpeed * Time.deltaTime;
            transform.rotation = new Quaternion(0, tempRotation, 0, 0);
            if (tempRotation >= startRotation - reach)
                turnRight = true;
        }
    }
}