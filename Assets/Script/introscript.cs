using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class introscript : MonoBehaviour
{

    public TextMeshProUGUI[] texts; // Metin nesneleri dizisi
    public GameObject intro; // Kapalý olmasý istenen GameObject
    public GameObject backButton,kaynaklar; // Geri butonu
    public TextMeshProUGUI timerText; // Süre sayaç metni
    private int currentTextIndex = 0; // Þu anki metin dizini
    public static float timer = 0f; // Sayaç
    public static bool timerRunning = false;
    private void Start()
    {
        ShowText(currentTextIndex);
        backButton.SetActive(false);
        timerText.gameObject.SetActive(false);
    }

    public void OnNextButtonClick()
    {
   
        currentTextIndex = (currentTextIndex + 1) % texts.Length;
        ShowText(currentTextIndex);

        if (currentTextIndex == texts.Length - 1)
        {
            CloseIntro();
        
            StartTimer();
            kaynaklar.SetActive(true);

        }

        backButton.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        currentTextIndex = (currentTextIndex - 1 + texts.Length) % texts.Length;
        ShowText(currentTextIndex);

        if (currentTextIndex == 0)
        {
            OpenIntro();
            backButton.SetActive(false);
        }
    }

    private void ShowText(int index)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == index);
        }
    }
    public void StopTimer()
    {
        timerRunning = false;
    }

    public void closeintrobutton()
    {
        CloseIntro();

        kaynaklar.SetActive(true) ;
        StartTimer();
    }

    private void CloseIntro()
    {
     
        if (intro != null)
        {
            intro.SetActive(false);
            timerRunning = true;
        }
    }

    private void OpenIntro()
    {
        if (intro != null)
        {
            intro.SetActive(true);
        }
    }

    private void StartTimer()
    {
        timerText.gameObject.SetActive(true);
        timer = 0f;
    }

    private void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
        UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {

        if (timerText != null)
        {
            timerText.text = timer.ToString("F2");
        }
    }

}