using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip buySound, btnClickDrop, gameWinSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        buySound = Resources.Load<AudioClip>("SFX_Buys");
        btnClickDrop = Resources.Load<AudioClip>("SFX_Drop");
        gameWinSound = Resources.Load<AudioClip>("SFX_Success");
        audioSource = GetComponent<AudioSource>();
    }
    public static void playFlipSound()
    {
        audioSource.PlayOneShot(btnClickDrop);
    }
    public static void PlayBtnClickSound()
    {
        audioSource.PlayOneShot(buySound);
    }
    public static void PlayGameWinSound()
    {
        audioSource.PlayOneShot(gameWinSound);
    }

}
