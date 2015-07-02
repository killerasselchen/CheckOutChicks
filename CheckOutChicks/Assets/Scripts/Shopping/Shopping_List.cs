//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class Shopping_List : MonoBehaviour
//{
//    public GameObject Kisten;
//    public GameObject Zeitschriften;
//    public GameObject Getraenke;
//    public GameObject Tchibo;
//    //public GameObject Irgendwas;
//    //public GameObject Suesskram;
//    //public GameObject Obst;
//    //public GameObject Tiernahrung;
//    //public GameObject Dosenfutter;

//    //private List<GameObject> BuybleItems;
//    private Gam
//    private int selection;

//    void Awake()
//    {
//        BuybleItems = GameObject.FindGameObjectsWithTag("Product");
//    }

//    void Start()
//    {
//        BuybleItems = new List<GameObject>();
//        AddBuyableItems();
//        SelectNextItem();
//    }

//    void Update()
//    {

//    }

//    void AddBuyableItems()
//    {
//        //can be fill now bei Tag "P1Trigger" "P2Trigger"...

//        BuybleItems.Add(Kisten);
//        BuybleItems.Add(Zeitschriften);
//        BuybleItems.Add(Getraenke);
//        BuybleItems.Add(Tchibo);
//        //BuybleItems.Add(Irgendwas);
//        //BuybleItems.Add(Suesskram);
//        //BuybleItems.Add(Obst);
//        //BuybleItems.Add(Tiernahrung);
//        //BuybleItems.Add(Dosenfutter);
//    }

//    void SelectNextItem()
//    {
//        if (BuybleItems.Capacity >= 0)
//        {
//            selection = Random.Range(0, BuybleItems.Count);
//            BuybleItems[selection].SetActive(true);
//        }

//        else if (BuybleItems.Capacity == 0)
//        {
//            GUI_RunPussyRun.SetActive(true);
//        }


//        //Can´t set new Text over GUITextNextItem.Text (only .GuiText will shows, but it doesen´t works at same way)
//    }

//    void OnTriggerStay(Collider other)
//    {
//        if (other.tag == "P1Trigger")
//        {
//            GUI_InTriggerZone.SetActive(true);

//            if (Input.GetKeyDown(KeyCode.Space))
//            {

//                //spawn Item into the Wagon is missing
//                //Copy to a nother List or make a List who files by Tags of Wagon and Item that spawnt

//                //Can´t Destroy the "old" selction!
//                BuybleItems[selection].SetActive(false);
//                BuybleItems.RemoveAt(selection);
//                //BuybleItems.RemoveAt(selection);
//                GUI_InTriggerZone.SetActive(false);

//                SelectNextItem();
//            }
//        }
//    }
//}
