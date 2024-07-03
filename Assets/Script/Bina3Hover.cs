using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bina3Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BinaYerlestirme bnb;
    public static string colorRed3 = "<color=red>Yetersiz : ";
    public static string colorgreen3 = "<color=green>Gerekli : ";
    

    public static bool Bina3demir_yeter;
    public static bool Bina3enerji_yeter;
    public static bool Bina3su_yeter;
    public static bool Bina3koloni_yeter;

    public static bool Bina3_hover;
 

    public void OnPointerEnter(PointerEventData eventData)
    {
        Bina3_hover = true;
        if(bnb.demirMiktar >= bnb.bina3DemirMaliyet)
        {
            Bina3demir_yeter = false;
        }
        else
        {
            Bina3demir_yeter = true;
        }
        if(bnb.enerjiMiktar >= bnb.bina3EnerjiMaliyet)
        {
            Bina3enerji_yeter = false;
        }
        else
        {
            Bina3enerji_yeter = true;
        }
        if(bnb.suMiktar >= bnb.bina3SuMaliyet)
        {
            Bina3su_yeter = false;
        }
        else
        {
            Bina3su_yeter = true;
        }
        if(bnb.kolonisayisi >= bnb.bina3KoloniMaliyet)
        {
            Bina3koloni_yeter = false;
        }
        else
        {
            Bina3koloni_yeter = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Bina3_hover = false;
    }
}
