using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bina1Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BinaYerlestirme bnb;
    public static string colorRed = "<color=red>Yetersiz: ";
    public static string colorgreen = "<color=green>Gerekli: ";



    public static bool Bina1enerji_yeter;
    public static bool Bina1demir_yeter;
    public static bool Bina1yemek_yeter;
    public static bool Bina1_hover;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover0");

        Bina1_hover = true;
       if (bnb.enerjiMiktar >= bnb.bina1EnerjiMaliyet)
        {
            Bina1enerji_yeter = false;
        }
        else
        {
            Bina1enerji_yeter = true;
        }
       if(bnb.demirMiktar >= bnb.bina1DemirMaliyet)
        {
            Bina1demir_yeter = false;
        }
        else
        {
            Bina1demir_yeter = true;
        }
        if (bnb.yemekmiktar >= bnb.bina1YemekMaliyet)
        {
            Bina1yemek_yeter = false;
        }
        else
        {
            Bina1yemek_yeter = true;
        }


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Bina1_hover = false;
    }
}
