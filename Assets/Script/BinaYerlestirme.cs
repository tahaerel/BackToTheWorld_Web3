using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinaYerlestirme : MonoBehaviour
{

    public int enerjiMiktar = 10;
    public int suMiktar = 50;
    public int demirMiktar = 1;
    public int yemekmiktar = 1;
    public int kolonisayisi = 1;


    public int bina1EnerjiMaliyet = 250;
    public int bina1DemirMaliyet = 150;
    public int bina1YemekMaliyet = 100;

    public int bina2DemirMaliyet = 20;

    public int bina3DemirMaliyet = 100;
    public int bina3EnerjiMaliyet = 10;
    public int bina3SuMaliyet= 50;
    public int bina3KoloniMaliyet = 2;

    public int bina4DemirMaliyet = 50;
    public int bina4EnergyMaliyet = 20;
    public int bina4koloniMaliyet = 1;

    public int bina5demirMmaliyet = 5000;
    public int bina5yenergyMaliyet = 1000;
    public int bina5ySuMaliyet = 1000;
    public int bina5KoloniMaliyet = 40;

    public int roverdemirmaliyet = 100;

    public int bina1UretimMiktari = 10;
    public int bina2UretimMiktari = 20;
    public int bina3UretimMiktari = 20;
    public int bina4UretimMiktari = 20;
    public int bina5UretimMiktari = 20;
    public int RoveruretimMiktari = 20;

    public Button upgradebutton;
    private void LateUpdate()
    {
        if (demirMiktar >= 1000)
        {
            upgradebutton.interactable = true;
        }
        else { upgradebutton.interactable = false;}
    }


}
