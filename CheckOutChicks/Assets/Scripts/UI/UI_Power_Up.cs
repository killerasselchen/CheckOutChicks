using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Power_Up : MonoBehaviour 
{
    //public GameObject confuse_Effect;
    //public GameObject sticky_Effect;
    //public GameObject turbo_Effect;
    
    
    //Alles noch viel zu unorganisiert. Die PowerUpListe aus dem PowerUpManager soll hiermit zusammen hängen
    public GameObject right_Confuse_Power_Up;
    public GameObject left_Confuse_Power_Up;
           
    public GameObject right_Sticky_Puddle_Power_Up;
    public GameObject left_Sticky_Puddle_Power_Up;
           
    public GameObject right_Turbo_Power_Up;
    public GameObject left_Turbo_Power_Up;

    public GameObject right_Slippery_Wet_Power_Up;
    public GameObject left_Slippery_Wet_Power_Up;

    public GameObject right_Point_Boost_Power_Up;
    public GameObject left_Point_Boost_Power_Up;

    public List<GameObject> rightPowerUps;
    public List<GameObject> leftPowerUps;
    
    void Awake()
    {
        SetPowerUpLists();
    }

    void SetPowerUpLists()
    {
        rightPowerUps.Add(right_Confuse_Power_Up);
        rightPowerUps.Add(right_Sticky_Puddle_Power_Up);
        rightPowerUps.Add(right_Turbo_Power_Up);

        leftPowerUps.Add(left_Confuse_Power_Up);
        leftPowerUps.Add(left_Sticky_Puddle_Power_Up);
        leftPowerUps.Add(left_Turbo_Power_Up);
    }

    public static void ActivateUI(GameObject name_Effect)
    {
        name_Effect.SetActive(true);
    }

    public static void DeActivateUI(GameObject name_Effect)
    {
        name_Effect.SetActive(false);
    }

}
