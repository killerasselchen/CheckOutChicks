//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;

public class Alt_Cam_Move : MonoBehaviour
{
    private Transform player;
    private Transform camAxis;
    public string playerNr;
    public string CameraNr;
    public string camAxisNr;

    private GameObject GameCamera;

    void Awake()
    {
       
    }

    void Start()
    {
        TagNameFinder();

        GameCamera = GameObject.FindGameObjectWithTag(CameraNr);
        ViewPortSelection();

        player = GameObject.FindGameObjectWithTag(playerNr).transform;
        camAxis = GameObject.FindGameObjectWithTag(camAxisNr).transform;
        transform.position = camAxis.position;
    }

    void FixedUpdate()
    {
        camAxis = GameObject.FindGameObjectWithTag(camAxisNr).transform;

        this.transform.position = new Vector3(camAxis.position.x, camAxis.position.y, camAxis.position.z);
        this.transform.LookAt(player);
    }

    void ViewPortSelection()
    {
        float x = 0;
        float y = 0;
        float width = 1;
        float height = 1;

        if (GameManager.setToTwoPlayers)
        {
            height = 0.5f;

            if (playerNr == "P_1")
                y = 0.5f; ;
        }

        else if (GameManager.setToThreePlayers)
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
        }

        else if (GameManager.setToFourPlayers)
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

        if (CameraNr == "Camera_1")
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
