using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour 
{
    [SerializeField]
    private Image[] PowerUpIcons;

    [SerializeField]
    private Sprite confuseIcon;
    [SerializeField]
    private Sprite stickyIcon;
    [SerializeField]
    private Sprite turboIcon;
    [SerializeField]
    private Sprite slipperyIcon;
    [SerializeField]
    private Sprite pointBoostIcon;
    
    void Awake()
    {
        //SetPowerUpLists();
    }

    //void SetIconList()
    //{

    //}

    public static void ActivateUI(GameObject PowerUpName)
    {
        PowerUpName.SetActive(true);
    }

    public static void DeActivateUI(GameObject PowerUpName)
    {
        PowerUpName.SetActive(false);
    }

    public void SetImage(int i, Sprite sprite)
    {
        PowerUpIcons[i].sprite = sprite;
    }
}
