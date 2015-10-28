//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using UnityEngine.UI;

public class MainUIElements : MonoBehaviour
{
    public static GameObject currentItem;
    
    //public Text GameTimer;

    private void FixedUpdate()
    {
        if (currentItem.transform.position == null)
        {
            currentItem.SetActive(false);
            Debug.Log("missing object in MainUiElements");
        }
           
        else
        {
            currentItem.SetActive(true);
            SetCamPosition();
        }
    }

    public void SetCamPosition()
    {
        transform.position = new Vector3(currentItem.transform.position.x, currentItem.transform.position.y, currentItem.transform.position.z - 1);
    }
}