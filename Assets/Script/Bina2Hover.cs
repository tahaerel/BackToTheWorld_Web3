using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bina2Hover : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler 
{
    public BinaYerlestirme bnb;
    public static string colorRed2 = "<color=red>Yetersiz : ";
    public static string colorgreen2 = "<color=green>Gerekli : ";
    public static bool Bina2demir_yeter;

    public static bool Bina2_hover;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Bina2_hover = true;
        if (bnb.demirMiktar >=  bnb.bina2DemirMaliyet)
        {
            Bina2demir_yeter = false;
        }
        else
        {
            Bina2demir_yeter = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover2");
        Bina2_hover = false;
    }
}
