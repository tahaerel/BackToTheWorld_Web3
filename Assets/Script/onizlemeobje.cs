using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onizlemeobje : MonoBehaviour
{
    public GameObject Olusacakobje;
    public float gridSize = 1.0f; // Kare boyutu
    RaycastHit hit;
    public Material materyal;
    bool olusturabilirmi;
    public MeshRenderer matcolor;
    public GameObject Gamemanager;
    public SpriteRenderer[] renderers;
    public static bool gridacik;


    public static bool olusturuldu;
    void Start()
    {

        Gamemanager = GameObject.Find("GameManager");
        olusturabilirmi = true;
        olusturuldu = false;
        UpdatePosition();
    }

    void UpdatePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000f, (1 << 8)))
        {
            Vector3 gridPosition = hit.point;
            gridPosition.x = Mathf.Floor(gridPosition.x / gridSize) * gridSize + gridSize / 2;
            gridPosition.y = Mathf.Floor(gridPosition.y / gridSize) * gridSize + gridSize / 2;
            gridPosition.z = Mathf.Floor(gridPosition.z / gridSize) * gridSize + gridSize / 2;

            transform.position = gridPosition;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("Zemin") && !other.gameObject.CompareTag("demir")&&!other.gameObject.CompareTag("su"))
        {
            Debug.Log("Çarpma var");

            GetComponent<MeshRenderer>().material.color = Color.red;

            for (int i = 0; i < matcolor.materials.Length; i++)
            {
                matcolor.materials[i].color = Color.red;
            }
            for (int j =0; j < renderers.Length; j++)
            {
                renderers[j].color=Color.red;
            }



            olusturabilirmi = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("Zemin"))
        {
            GetComponent<MeshRenderer>().material = materyal;

            for (int i = 0; i < matcolor.materials.Length; i++)
            {
                matcolor.materials[i].CopyPropertiesFromMaterial(materyal);
            }
            for (int j = 0; j < renderers.Length; j++)
            {
                renderers[j].color = Color.green;
            }

            olusturabilirmi = true;
        }
    }

    void Update()
    {
        UpdatePosition();
        gridacik = true;
        if (Input.GetMouseButton(0))
        {
            if (olusturabilirmi)
            {
                    
             Instantiate(Olusacakobje, transform.position, transform.rotation);
                SoundManagerScript.playFlipSound();
             olusturuldu = true;
             Destroy(gameObject);
                gridacik = false;

            }
        }

        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);

            gridacik = false;

            switch (objesec.index)
            {
              case 0:


                    Gamemanager.GetComponent<BinaYerlestirme>().enerjiMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina1EnerjiMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().demirMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina1DemirMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().yemekmiktar+= Gamemanager.GetComponent<BinaYerlestirme>().bina1YemekMaliyet;

                    break;
                case 1:


                  
                    Gamemanager.GetComponent<BinaYerlestirme>().demirMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina2DemirMaliyet;
                   

                    break;
                case 2:


                    Gamemanager.GetComponent<BinaYerlestirme>().enerjiMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina3EnerjiMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().demirMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina3DemirMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().suMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina3SuMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().kolonisayisi+= Gamemanager.GetComponent<BinaYerlestirme>().bina3KoloniMaliyet;

                    break;
                case 3:


                    Gamemanager.GetComponent<BinaYerlestirme>().enerjiMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina4EnergyMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().demirMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina4DemirMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().kolonisayisi += Gamemanager.GetComponent<BinaYerlestirme>().bina4koloniMaliyet;

                    break;
                case 4:


                    Gamemanager.GetComponent<BinaYerlestirme>().enerjiMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina5yenergyMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().demirMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina5demirMmaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().suMiktar += Gamemanager.GetComponent<BinaYerlestirme>().bina5ySuMaliyet;
                    Gamemanager.GetComponent<BinaYerlestirme>().kolonisayisi += Gamemanager.GetComponent<BinaYerlestirme>().bina5KoloniMaliyet;

                    break;

            }
        }
    }
}
