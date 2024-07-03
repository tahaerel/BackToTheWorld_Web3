using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bina4Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BinaYerlestirme bnb;
    public static string colorRed4 = "<color=red>Yetersiz : ";
    public static string colorgreen4 = "<color=green>Gerekli : ";


    public static bool Bina4demir_yeter;
    public static bool Bina4enerji_yeter;
    
    public static bool Bina4koloni_yeter;


    public static bool Bina4_hover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Bina4_hover = true;
        if (bnb.demirMiktar >= bnb.bina4DemirMaliyet)
        {
            Bina4demir_yeter = false;
        }
        else
        {
            Bina4demir_yeter = true;
        }
        if (bnb.enerjiMiktar >= bnb.bina4EnergyMaliyet)
        {
            Bina4enerji_yeter = false;
        }
        else
        {
            Bina4enerji_yeter = true;
        }
      
        if (bnb.kolonisayisi >= bnb.bina4koloniMaliyet)
        {
            Bina4koloni_yeter = false;
        }
        else
        {
            Bina4koloni_yeter = true;
        }
    
}

    public void OnPointerExit(PointerEventData eventData)
    {
        Bina4_hover = false;
    }
}
