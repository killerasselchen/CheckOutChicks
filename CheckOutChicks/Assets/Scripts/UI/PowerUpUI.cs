using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField]
    private Image[] PowerUpIcons;

    [SerializeField]
    public Sprite emptySlotIcon;

    [SerializeField]
    private Sprite confuseIcon;

    [SerializeField]
    private Sprite pointBoostIcon;
    
    [SerializeField]
    private Sprite slipperyIcon;

    [SerializeField]
    private Sprite stickyIcon;

    [SerializeField]
    private Sprite turboIcon;

    public void SetImage(int i, Sprite sprite)
    {
        PowerUpIcons[i].sprite = sprite;
    }

    public void ClearImage(int i)
    {
        PowerUpIcons[i].sprite = emptySlotIcon;
    }

    private void Awake()
    {
        //SetPowerUpLists();
    }

    //void SetIconList()
    //{
    //}

    //public static void ActivateUI(GameObject PowerUpName)
    //{
    //    PowerUpName.SetActive(true);
    //}

    //public static void DeActivateUI(GameObject PowerUpName)
    //{
    //    PowerUpName.SetActive(false);
    //}
}