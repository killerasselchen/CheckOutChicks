//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Camera_Movements : MonoBehaviour {


    private float smooth = 4f;

    private Transform player;
    public string playerNr;

    private Transform camAxis;
    public string camAxisNr;

    public string CameraNr;

    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 tempPos;

    void Start()
    {
        TagNameFinder();

        player = GameObject.FindGameObjectWithTag(playerNr).transform;
        camAxis = GameObject.FindGameObjectWithTag(camAxisNr).transform;

        ViewPortSelection();

        transform.position = camAxis.position;
        relCameraPos = transform.position - player.position;
        relCameraPosMag = relCameraPos.magnitude - 1.0f;
    }
	
	void FixedUpdate() 
    {
        Vector3 standardPos = camAxis.position;
        Vector3 nearestPos = player.position;
        Vector3[] checkPoints = new Vector3[6];
        
        checkPoints[0] = standardPos;
        checkPoints[1] = Vector3.Lerp(standardPos, nearestPos, 0.2f);
        checkPoints[2] = Vector3.Lerp(standardPos, nearestPos, 0.4f);
        checkPoints[3] = Vector3.Lerp(standardPos, nearestPos, 0.6f);
        checkPoints[4] = Vector3.Lerp(standardPos, nearestPos, 0.8f);
        checkPoints[5] = nearestPos;

        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (ViewingPosCheck(checkPoints[i]))
                break;
        }

        transform.position = Vector3.Lerp(transform.position, tempPos, smooth * Time.deltaTime);

        LookAtPlayer();
	}

    bool ViewingPosCheck (Vector3 checkPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(checkPoint, player.position - checkPoint, out hit, relCameraPosMag))
        {
            if (hit.transform != player)
            {
                return false;
            }
        }

        tempPos = checkPoint;
        return true;
    }

    //Rotate smoothly the Camera behind the Players-Rotation
    void LookAtPlayer()
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
        this.GetComponent<Camera>().rect = new Rect(x, y, width, height);
    }

    //"Spieler zuweisung" oder ähnlich müßte es heißen. Name finden!!
    //Use the Tag for set the right Tag-Information for Player- and CameraPosition-References.
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
