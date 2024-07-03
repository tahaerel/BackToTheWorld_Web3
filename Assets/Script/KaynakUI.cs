using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KaynakUI : MonoBehaviour
{
    public BinaYerlestirme kaynak;

    public TextMeshProUGUI enerjiUI;
    public TextMeshProUGUI suiUI;
    public TextMeshProUGUI demirUI;
    public TextMeshProUGUI yemekUI;
    public TextMeshProUGUI koloniUI;

    void Update()
    {
        enerjiUI.text = kaynak.enerjiMiktar.ToString();
        suiUI.text = kaynak.suMiktar.ToString();
        demirUI.text = kaynak.demirMiktar.ToString();
        yemekUI.text = kaynak.yemekmiktar.ToString();
        koloniUI.text = kaynak.kolonisayisi.ToString();
    }
}
