using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public static bool kolonigorevibasarili=false;
    public static bool roketgorevibasarili = false;
    public  int oyuntamamlandi = 0;
    public GameObject Finishcanvas;
    public GameObject leaderboard, ResearchPanel;

    public Image Kolonitask, Rockettask;

    void LateUpdate()
    {
        if (kolonigorevibasarili)
        { Kolonitask.GetComponent<Image>().color = new Color32(50, 166, 51, 255);
            SoundManagerScript.PlayGameWinSound();
            kolonigorevibasarili = false;
        }

        if (roketgorevibasarili && oyuntamamlandi==0)
        { Rockettask.GetComponent<Image>().color = new Color32(50, 166, 51, 255);
            SoundManagerScript.PlayGameWinSound();

            introscript.timerRunning = false;
            Finishcanvas.SetActive(true);
            oyuntamamlandi++;
        }
        if (ObjectClick.panelopen)
        {
            ResearchPanel.SetActive(true );
        }
        else { ResearchPanel.SetActive(false); }


    }
    public void leaderboardkapa()
    {
        leaderboard.SetActive(false);

    }
    public void research_panel_close()
    {
        ObjectClick.panelopen = false;
    }

    public void xbutton()
    {
        Finishcanvas.SetActive(false);
        leaderboard.SetActive(true);

    }
}
