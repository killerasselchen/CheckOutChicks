using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField]
    private Image[] PowerUpIcons;

    public Text PointsText;

    [SerializeField]
    public Sprite emptySlotIcon;

    public void SetImage(int i, Sprite sprite)
    {
        PowerUpIcons[i].sprite = sprite;
    }

    public void ClearImage(int i)
    {
        PowerUpIcons[i].sprite = emptySlotIcon;
    }
}