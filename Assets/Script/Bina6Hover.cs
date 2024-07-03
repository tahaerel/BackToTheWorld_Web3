using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bina6Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BinaYerlestirme bnb;
    public static string colorRed6 = "<color=red>Yetersiz : ";
    public static string colorgreen6 = "<color=green>Gerekli : ";
    public static bool Bina6demir_yeter;

    public static bool Bina6_hover;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Bina6_hover = true;
        if (bnb.demirMiktar >= bnb.roverdemirmaliyet)
        {
            Bina6demir_yeter = false;
        }
        else
        {
            Bina6demir_yeter = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Bina6_hover = false;
    }
}
