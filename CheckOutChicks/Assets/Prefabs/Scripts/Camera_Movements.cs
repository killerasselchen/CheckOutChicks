//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Camera_Movements : MonoBehaviour {

    private float smooth = 4f;

    private Transform player;
    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 newPos;
    private Transform camAxis;
    public string playerNr;
    public string CameraNr;
    public string camAxisNr;

    private GameObject GameCamera;

    void Awake()
    {
        //TagNameFinder();

        //Camera_1 = GameObject.FindGameObjectWithTag(CameraNr);
        //ViewPortSelection();
        
        //player = GameObject.FindGameObjectWithTag(playerNr).transform;
        //camAxis = GameObject.FindGameObjectWithTag(camAxisNr).transform;
        //relCameraPos = transform.position - player.position;
        //relCameraPosMag = relCameraPos.magnitude - 0.5f;

    }

    void Start()
    {
        TagNameFinder();

        GameCamera = GameObject.FindGameObjectWithTag(CameraNr);
        ViewPortSelection();

        player = GameObject.FindGameObjectWithTag(playerNr).transform;
        camAxis = GameObject.FindGameObjectWithTag(camAxisNr).transform;
        transform.position = camAxis.position;
        relCameraPos = transform.position - player.position;
        relCameraPosMag = relCameraPos.magnitude;
        //Camera.main.GetComponent<Camera_Movements>().enabled = false;


    }
	
	void FixedUpdate() 
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 standardPos = camAxis.position;
        Vector3 abovePos = player.position;
        Vector3[] checkPoints = new Vector3[5];
        
        checkPoints[0] = standardPos;

        checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
        checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
        checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);
        checkPoints[4] = abovePos;

        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (ViewingPosCheck(checkPoints[i]))
                break;
        }

        transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);

        SmoothLookAt();
	}

    bool ViewingPosCheck (Vector3 checkPos)
    {
        RaycastHit hit;

        if (Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag))
        {
            if (hit.transform != player)
            {
                return false;
            }

        }

        newPos = checkPos;
        return true;
    }

    void SmoothLookAt()
    {
        Vector3 relPlayerPosition = player.position - transform.position;

        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
    }

    void ViewPortSelection()
    {
        float x = 0;
        float y = 0;
        float width = 1;
        float height = 1;
       
        if (GameManager.SetToTwoPlayers)
        {
            height = 0.5f;
            
            if(playerNr == "P_1")
                y = 0.5f; ;
        }

        else if (GameManager.SetToThreePlayers)
        {
            width = 0.5f;
            height = 0.5f;

            if(playerNr == "P_1")
            {
                x = 0.0f;
                y = 0.5f;
            }
            else if(playerNr == "P_2")
            {
                x = 0.5f;
                y = 0.5f;
            }
            else if (playerNr == "P_3")
            {
                x = 0.0f;
            }
        }

        else if (GameManager.SetToFourPlayers)
        {
            width = 0.5f;
            height = 0.5f;

            if (playerNr == "P_1")
            {
                x = 0.0f;
                y = 0.5f;
            }
            else if (playerNr == "P_2")
            {
                x = 0.5f;
                y = 0.5f;
            }
            else if (playerNr == "P_3")
            {
                x = 0.0f;
            }
            else if (playerNr == "P_4")
            {
                x = 0.5f;
            }
        }
        GameCamera.GetComponent<Camera>().rect = new Rect(x, y, width, height);
    }

    //"Spieler zuweisung" oder ähnlich müßte es heißen. Name finden!!
    void TagNameFinder()
    {
        CameraNr = this.gameObject.tag;

        if(CameraNr == "Camera_1")
        {
            playerNr = "P_1";
            camAxisNr = "Cam_Pos_1";
        }
        else if (CameraNr == "Camera_2")
        {
            playerNr = "P_2";
            camAxisNr = "Cam_Pos_2";
        }
        else if (CameraNr == "Camera_3")
        {
            playerNr = "P_3";
            camAxisNr = "Cam_Pos_3";
        }
        else if (CameraNr == "Camera_4")
        {
            playerNr = "P_4";
            camAxisNr = "Cam_Pos_4";
        }
    }
}
