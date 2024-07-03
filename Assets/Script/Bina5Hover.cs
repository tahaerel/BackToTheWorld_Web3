using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bina5Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BinaYerlestirme bnb;
    public static string colorRed5 = "<color=red>Yetersiz : ";
    public static string colorgreen5 = "<color=green>Gerekli : ";


    public static bool Bina5demir_yeter;
    public static bool Bina5enerji_yeter;
    public static bool Bina5su_yeter;

    public static bool Bina5koloni_yeter;


    public static bool Bina5_hover;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Bina5_hover = true;
        if (bnb.demirMiktar >= bnb.bina5demirMmaliyet)
        {
            Bina5demir_yeter = false;
        }
        else
        {
            Bina5demir_yeter = true;
        }
        if (bnb.enerjiMiktar >= bnb.bina5yenergyMaliyet)
        {
            Bina5enerji_yeter = false;
        }
        else
        {
            Bina5enerji_yeter = true;
        }
        if (bnb.suMiktar >= bnb.bina5ySuMaliyet)
        {
            Bina5su_yeter = false;
        }
        else
        {
            Bina5su_yeter = true;
        }

        if (bnb.kolonisayisi >= bnb.bina5KoloniMaliyet)
        {
            Bina5koloni_yeter = false;
        }
        else
        {
            Bina5koloni_yeter = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Bina5_hover = false;
    }
}
