using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceChanger : MonoBehaviour
{
    public GameObject Gamemanager;
    public int enerji,su,demir,yemek,koloni;
    public float zamanAraligi = 10f;
    public int Binaid;
    public bool is_stone;
    public bool is_water;
    public GameObject textobjesi;
    public TextMeshPro puantext;
    void Start()
    {
      

        Gamemanager = GameObject.Find("GameManager");
        switch (Binaid)
        {
            case 0:
                ArtirKoloni();
                break;

            case 1:
                InvokeRepeating("ArtirEnerji", zamanAraligi, zamanAraligi);
                break;
            case 2:
                InvokeRepeating("ArtirYemek", zamanAraligi, zamanAraligi);

                break;
            case 3:
                StartCoroutine(water_stonect());
                break;

            case 4:
                Debug.Log("case 4 ");
                MissionManager.roketgorevibasarili = true;
                break;
        }
 
    }
    IEnumerator water_stonect()
    {
        yield return new WaitForSeconds(1.2f);
        if (is_water)
        {
            InvokeRepeating("ArtirSu", zamanAraligi, zamanAraligi);
            is_water = false;
        }

        else if (is_stone)
        {
            InvokeRepeating("Arttirdemir", zamanAraligi, zamanAraligi);
            is_stone = false;
        }
    }

  
    void ArtirKoloni()
    {
        puantext.text = "+" + koloni.ToString();
        textobjesi.SetActive(true);
        Invoke("DisableText", 1.5f);

        Gamemanager.GetComponent<BinaYerlestirme>().kolonisayisi += koloni;
        if (Gamemanager.GetComponent<BinaYerlestirme>().kolonisayisi >= 20)
        {
            MissionManager.kolonigorevibasarili = true;
        }
    }
    void ArtirEnerji()
    {
        puantext.text = "+" + enerji.ToString();
        textobjesi.SetActive(true);
        Gamemanager.GetComponent<BinaYerlestirme>().enerjiMiktar += enerji;
        Invoke("DisableText", 1.5f);

    }

    void ArtirSu()
    {
        puantext.text = "+" + su.ToString();
        textobjesi.SetActive(true);
        Gamemanager.GetComponent<BinaYerlestirme>().suMiktar += su;
        Invoke("DisableText", 1.5f);

    }
    void Arttirdemir()
    {
        puantext.text = "+" + demir.ToString();
        textobjesi.SetActive(true);
        Gamemanager.GetComponent<BinaYerlestirme>().demirMiktar+= demir;
        Invoke("DisableText", 1.5f);
    }
    void ArtirYemek()
    {
        puantext.text = "+" + yemek.ToString();
        textobjesi.SetActive(true);
        Gamemanager.GetComponent<BinaYerlestirme>().yemekmiktar += yemek;
        Invoke("DisableText", 1.5f);
    }
    void DisableText()
    {
        // Animator'ý devre dýþý býrak
        textobjesi.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "demir")
        {
            Debug.Log("Demirdesin");
            is_stone = true;
        }
        if (other.gameObject.tag == "su")
        {
            Debug.Log("Sudasýn");
            is_water = true;
        }
    }
}
