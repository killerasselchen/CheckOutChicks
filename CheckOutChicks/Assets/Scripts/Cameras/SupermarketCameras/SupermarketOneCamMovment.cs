using UnityEngine;

public class SupermarketOneCamMovment : MonoBehaviour
{
    private float maxReach;
    private float minReach;
    private float rotationSpeed;
    [SerializeField]
    private Quaternion startRotation;
    [SerializeField]
    private Quaternion tempRotation;
    private bool turnRight = true;
    [SerializeField]
    private float yTemp;

    public void Start()
    {
        yTemp = 0;
        startRotation = this.transform.rotation;
        //maxReach = new Quaternion(startRotation.x,startRotation.y +10,startRotation.z,startRotation.w);
        //mminReach = new Quaternion(startRotation.x, startRotation.y - 10, startRotation.z, startRotation.w);
        maxReach = 300;
        //minReach = 10;
        rotationSpeed = 5;
        tempRotation = startRotation;
    }

    public void Spin()
    {
        if (turnRight)
        {
            yTemp += 1 * Time.deltaTime;
            tempRotation = new Quaternion(startRotation.x,startRotation.y + yTemp,startRotation.z,startRotation.w);
            transform.rotation = tempRotation;
            if (tempRotation.y >= startRotation.y + maxReach)
            {
                turnRight = false;
                Debug.Log("turn switch");
            }
                
        }
        else if(!turnRight)
        {
            yTemp -= 1 * Time.deltaTime;
            tempRotation = new Quaternion(startRotation.x, startRotation.y + yTemp, startRotation.z, startRotation.w);
            transform.rotation = tempRotation;
            if (tempRotation.y <= startRotation.y - maxReach)
                turnRight = true;
        }
    }

    public void Update()
    {
        Spin();
    }
}