using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private static Menu instance = null;

    private AudioSource muzikKaynagi;
    public GameObject hazirlayanlarpanel;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
     
        muzikKaynagi = GetComponent<AudioSource>();

       
        if (!muzikKaynagi.isPlaying)
        {
            muzikKaynagi.Play();
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void hazirlayanlar()
    {

        hazirlayanlarpanel.SetActive(true);   
            
     }
    public void hazirlayanlarkapa()
    {

        hazirlayanlarpanel.SetActive(false);

    }

    public void exitgame()
    {

        Application.Quit();

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" && !muzikKaynagi.isPlaying)
        {
            muzikKaynagi.Play();
        }
    }
}
