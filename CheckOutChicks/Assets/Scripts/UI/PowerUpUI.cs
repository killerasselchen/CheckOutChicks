//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

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