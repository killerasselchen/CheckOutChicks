using UnityEngine;
using System.Collections;

public class Speedometer : MonoBehaviour {

    private Vector3 lastPosition;
    private float speed;
    private int playerNr;

    public float Speed
    {
        get { return speed; }
        private set { speed = value; }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void tacho()
    {
        speed = (this.transform.position - lastPosition).magnitude / Time.deltaTime;
        speed = speed * 100;
        lastPosition = this.transform.position;
        
        ////Alte Version. Hier würde das ganze noch auf den jeweiligen UI´s angezeigt werden(splitt des Tags wäre nötig um die Spieler nummer zu bekommen)
        //for (int i = 0; i < GameManager.activeCameras.Count; i++)
        //{
        //    Debug.Log("@time");
        //    speed = (this.transform.position - lastPosition).magnitude / Time.deltaTime;
        //    speed = speed * 100;

        //    if (i + 1 == playerNr)
        //    {
        //        Debug.Log("@TextMesh");

        //        GameManager.activeCameras[i].GetComponentInChildren<TextMesh>().text = speed.ToString("0.");
        //        lastPosition = this.transform.position;
        //    }
        //}
    }
}
