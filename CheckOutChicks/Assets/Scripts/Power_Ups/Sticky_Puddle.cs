using UnityEngine;
using System.Collections;

public class Sticky_Puddle : MonoBehaviour {

    private string powerUpName;
    private int playerNr;

    // Use this for initialization
    void Awake()
    {
        powerUpName = gameObject.name;
        string temp = powerUpName.Split('_')[1];
        playerNr = int.Parse(temp) - 1;
    }

    // Update is called once per frame
    void Update()
    {
        MovePowerUp();
    }

    void MovePowerUp()
    {
        if (playerNr == 1)
            this.transform.position = GameManager.camera_1.transform.position;
        else if (playerNr == 2)
            this.transform.position = GameManager.camera_2.transform.position;
        else if (playerNr == 3)
            this.transform.position = GameManager.camera_3.transform.position;
        else if (playerNr == 4)
            this.transform.position = GameManager.camera_4.transform.position;
    }
}
