//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private float smooth = 3f;

    public Transform player_Position;

    public Transform camOrigin;
    private string cam_Origin_Tag;
    public Transform camTarget;
    //public string cam_Target_Tag;

    private string cam_Tag;

    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 tempPos;

    private void Start()
    {
        //TagNameFinder();

        //player_Position = GameObject.FindGameObjectWithTag("Player_" + this.gameObject.name.Split('_')[1]).transform;
        //cam_Origin = GameObject.FindGameObjectWithTag(cam_Origin_Tag).transform;
        //cam_Target = GameObject.FindGameObjectWithTag(cam_Target_Tag).transform;

        //ViewPortSelection();

        transform.position = camOrigin.position;
        relCameraPos = transform.position - player_Position.position;
        relCameraPosMag = relCameraPos.magnitude - 1.0f;
    }

    private void FixedUpdate()
    {
        Vector3 standardPos = camOrigin.position;
        Vector3 nearestPos = player_Position.position;
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

    private bool ViewingPosCheck(Vector3 checkPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(checkPoint, camTarget.position - checkPoint, out hit, relCameraPosMag))
        {
            if (hit.transform != camTarget)
            {
                return false;
            }
        }

        tempPos = checkPoint;
        return true;
    }

    //Rotate smoothly the Camera behind the Players-Rotation
    private void LookAtPlayer()
    {
        Vector3 relPlayerPosition = camTarget.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
    }

    //TODO: Kommentar entfernen.
    //im GameManager nutzen - GGF Instatiate Player -> Cam -> Rect & next Player...
    //private void ViewPortSelection()
    //{
    //    float x = 0;
    //    float y = 0;
    //    float width = 1;
    //    float height = 1;

    //    if (game_Manager.setToTwoPlayers)
    //    {
    //        height = 0.5f;

    //        if (playerNr == "P_1")
    //            y = 0.5f;
    //    }
    //    else if (game_Manager.setToThreePlayers)
    //    {
    //        width = 0.5f;
    //        height = 0.5f;

    //        if (playerNr == "P_1")
    //        {
    //            x = 0.0f;
    //            y = 0.5f;
    //        }
    //        else if (playerNr == "P_2")
    //        {
    //            x = 0.5f;
    //            y = 0.5f;
    //        }
    //        else if (playerNr == "P_3")
    //        {
    //            x = 0.0f;
    //        }
    //    }
    //    else if (game_Manager.setToFourPlayers)
    //    {
    //        width = 0.5f;
    //        height = 0.5f;

    //        if (playerNr == "P_1")
    //        {
    //            x = 0.0f;
    //            y = 0.5f;
    //        }
    //        else if (playerNr == "P_2")
    //        {
    //            x = 0.5f;
    //            y = 0.5f;
    //        }
    //        else if (playerNr == "P_3")
    //        {
    //            x = 0.0f;
    //        }
    //        else if (playerNr == "P_4")
    //        {
    //            x = 0.5f;
    //        }
    //    }
    //    this.GetComponent<Camera>().rect = new Rect(x, y, width, height);
    //}

    //"Spieler zuweisung" oder ähnlich müßte es heißen. Name finden!!
    //Use the Tag for set the right Tag-Information for Player- and CameraPosition-References.
    //private void TagNameFinder()
    //{
    //    cam_Tag = this.gameObject.tag;

    //    playerNr = "P_" + cam_Tag.Split('_')[1];
    //    cam_Origin_Tag = "Cam_Pos_" + cam_Tag.Split('_')[1];
    //    cam_Target_Tag = "Cam_Target_" + cam_Tag.Split('_')[1];
    //}
}