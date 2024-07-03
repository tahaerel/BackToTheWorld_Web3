using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    private float baslangicDegeri = 70f;
    private float baslangicDegeri2 = 35f;
    private float hedefDeger = 200f;
    private float artisHizi = 10f;

    public float hareketHizi = 5f;

    void Update()
    {
        HareketEt();
    }

    void HareketEt()
    {
        transform.Translate(Vector3.right * hareketHizi * Time.deltaTime);
    }
    public void FogDistanceRover()
    {

        StartCoroutine(FogArttir());

    }
    private void Start()
    {
        StartCoroutine(FogArttir());

    }

    System.Collections.IEnumerator FogArttir()
    {
        float suankiDeger = baslangicDegeri;

        while (suankiDeger < hedefDeger)
        {
            suankiDeger += artisHizi * Time.deltaTime;

            RenderSettings.fogEndDistance = suankiDeger;

            yield return null;
        }


        StartCoroutine(FogStartArttir());
        Debug.Log("Fog Start Distance Hedef");
    }

    System.Collections.IEnumerator FogStartArttir()
    {
        float suankiDeger2 = baslangicDegeri2;

        while (suankiDeger2 < hedefDeger)
        {
            suankiDeger2 += artisHizi * Time.deltaTime;

            RenderSettings.fogStartDistance = suankiDeger2;

            yield return null;
        }
        RenderSettings.fog = false;
        Destroy(this.gameObject);
    }




}
