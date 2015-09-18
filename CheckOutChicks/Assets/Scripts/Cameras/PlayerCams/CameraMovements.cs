//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public Transform camOrigin;
    public Transform camTarget;
    public Transform player_Position;
    private string cam_Origin_Tag;
    private string cam_Tag;
    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private float smooth = 6f;
    private Vector3 tempPos;

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

    private void LookAtPlayer()
    {
        Vector3 relPlayerPosition = camTarget.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
    }

    private void Start()
    {
        transform.position = camOrigin.position;
        relCameraPos = transform.position - player_Position.position;
        relCameraPosMag = relCameraPos.magnitude - 1.0f;
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
}