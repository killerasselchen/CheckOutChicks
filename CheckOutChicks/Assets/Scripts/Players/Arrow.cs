//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class Arrow : MonoBehaviour 
//{
//    private Vector3 target;

//    // Update is called once per frame
//    void Update () 
//    {
//        this.transform.LookAt(target, Vector3.up);
//    }

//    public void PointToTarget(Item newItem)
//    {
//        newItem.OnItemDeactivation += Deactivate;
//        target = newItem.transform.position;
//    }

//    private void Deactivate(Item item)
//    {
//        item.OnItemDeactivation -= Deactivate;
//        this.gameObject.SetActive(false);
//    }
//}
