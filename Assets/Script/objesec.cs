using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objesec : MonoBehaviour
{
    public GameObject[] OnizlemeObjeler;
    public GameObject Rover;
    public static bool butona_tiklandi;
    public BinaYerlestirme bnb;
    public GameObject Error,RoverButton,Roverimage;
    public static int index;
    public Image Rovertask;


    //private void Update()
    //{
    //    if(bnb.enerjiMiktar >= bnb.bina1EnerjiMaliyet)
    //    {

    //    }
    //}
    public void olustur(int deger)
    {

        index = deger;

        switch (deger)
        {
            case 0:
                SoundManagerScript.PlayBtnClickSound();

                if (bnb.enerjiMiktar >= bnb.bina1EnerjiMaliyet && bnb.demirMiktar >= bnb.bina1DemirMaliyet && bnb.yemekmiktar >= bnb.bina1YemekMaliyet)
                {
                    Instantiate(OnizlemeObjeler[deger]);


                    bnb.enerjiMiktar -= bnb.bina1EnerjiMaliyet;
                    bnb.demirMiktar -= bnb.bina1DemirMaliyet;
                    bnb.yemekmiktar -= bnb.bina1YemekMaliyet;
                  
                }
                else
                {
                    Error.SetActive(true);
                    StartCoroutine(DeactivateErrorAfterDelay(1.5f));
                }
                break;
            case 1:
                SoundManagerScript.PlayBtnClickSound();

                if (bnb.demirMiktar >= bnb.bina2DemirMaliyet)
                {
                    bnb.demirMiktar -= bnb.bina2DemirMaliyet;
                  
                    Instantiate(OnizlemeObjeler[deger]);
                }
                else
                {
                    Error.SetActive(true);
                    StartCoroutine(DeactivateErrorAfterDelay(1.5f));

                }
                break;
            case 2:
                SoundManagerScript.PlayBtnClickSound();

                if (bnb.demirMiktar >= bnb.bina3DemirMaliyet && bnb.enerjiMiktar >= bnb.bina3EnerjiMaliyet && bnb.suMiktar >= bnb.bina3SuMaliyet && bnb.kolonisayisi >= bnb.bina3KoloniMaliyet)
                {
                    bnb.demirMiktar -= bnb.bina3DemirMaliyet;
                    bnb.enerjiMiktar -= bnb.bina3EnerjiMaliyet;
                    bnb.suMiktar -= bnb.bina3SuMaliyet;
                    bnb.kolonisayisi -= bnb.bina3KoloniMaliyet;
                    Instantiate(OnizlemeObjeler[deger]);
                }

                else
                {
                    Error.SetActive(true);
                    StartCoroutine(DeactivateErrorAfterDelay(1.5f));

                }
                break;
            case 3:
                SoundManagerScript.PlayBtnClickSound();

                if (bnb.demirMiktar >= bnb.bina4DemirMaliyet && bnb.kolonisayisi >= bnb.bina4koloniMaliyet && bnb.enerjiMiktar >= bnb.bina4EnergyMaliyet)
                {
                    bnb.demirMiktar -= bnb.bina4DemirMaliyet;
                    bnb.kolonisayisi -= bnb.bina4koloniMaliyet;
                    bnb.enerjiMiktar -= bnb.bina4EnergyMaliyet;
                
                    Instantiate(OnizlemeObjeler[deger]);
                }
                else
                {
                    Error.SetActive(true);
                    StartCoroutine(DeactivateErrorAfterDelay(1.5f));

                }

                break;
            case 4:
                SoundManagerScript.PlayBtnClickSound();

                if (bnb.demirMiktar >= bnb.bina5demirMmaliyet && bnb.enerjiMiktar >= bnb.bina5yenergyMaliyet && bnb.suMiktar >= bnb.bina5ySuMaliyet && bnb.kolonisayisi >= bnb.bina5KoloniMaliyet)
                    {   
                    bnb.demirMiktar -= bnb.bina5demirMmaliyet;
                    bnb.enerjiMiktar -= bnb.bina5yenergyMaliyet;
                    bnb.suMiktar -= bnb.bina5ySuMaliyet;
                    bnb.kolonisayisi -= bnb.bina5KoloniMaliyet;
                    Instantiate(OnizlemeObjeler[deger]);
                    }
                else
                {
                    Error.SetActive(true);
                    StartCoroutine(DeactivateErrorAfterDelay(1.5f));

                }


                break;

            case 5:
                SoundManagerScript.PlayBtnClickSound();

                if (bnb.demirMiktar >= bnb.roverdemirmaliyet)
                {
                    bnb.demirMiktar -= bnb.roverdemirmaliyet;

                    Rovertask.GetComponent<Image>().color = new Color32(50, 166, 51, 255);
                    SoundManagerScript.PlayGameWinSound();


                    Vector3 kameraPozisyon = Camera.main.transform.position;

                    Vector3 kameraYonu = Camera.main.transform.forward;

                    Vector3 olusturulacakPozisyon = kameraPozisyon + kameraYonu * 50.0f;

                    olusturulacakPozisyon.y = 1;

                    GameObject yeniObje = Instantiate(Rover, olusturulacakPozisyon, Quaternion.identity);

                    yeniObje.transform.rotation = Quaternion.Euler(0, 180, 0);

                    RoverButton.GetComponent<Button>().interactable=false;
                    Roverimage.GetComponent<Button>().interactable = false;
                }
                else
                {
                    Error.SetActive(true);
                    StartCoroutine(DeactivateErrorAfterDelay(1.5f));

                }
                break;
                    default:

                break;
        }

    }

    IEnumerator DeactivateErrorAfterDelay(float delay)
    {  
        yield return new WaitForSeconds(delay);

        Error.SetActive(false);
    }



}
