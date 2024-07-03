using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class LeaderBoard : MonoBehaviour
{
    private const string phpURL = "https://www.pushup.games/savescore.php"; // PHP dosyanýzýn URL'si
    private const string phpgetURL = "https://www.pushup.games/get_leaderboard.php"; // PHP dosyanýzýn URL'si
    public TextMeshProUGUI leaderboardText;
    public GameObject datagondermeekrani,scoretablo;

    public TMP_InputField nameinput;

    public string playerName;
    public float playerScore;

    private void Start()
    {
        playerScore = introscript.timer;
        GetScoreFromServer();
    }

 
    public void SendScoreToServer()
    {
        StartCoroutine(SendScore());
        GetScoreFromServer();
        datagondermeekrani.SetActive(false);
        scoretablo.SetActive(true);

    }
    public void GetScoreFromServer()
    {
        StartCoroutine(GetLeaderboard());
    }

    IEnumerator SendScore()
    {
        playerName = nameinput.text;

        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("playerScore", introscript.timer.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(phpURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error sending score: " + www.error);
            }
            else
            {
                Debug.Log("Score sent successfully!");
            }
        }
    }
    public void kapatbuton()
    {
        datagondermeekrani.SetActive(false);
        scoretablo.SetActive(true);

    }

   


    IEnumerator GetLeaderboard()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(phpgetURL))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error getting leaderboard: " + www.error);
                // Eðer 500 Internal Server Error alýnýrsa, dosya bulunamamýþ olabilir.
                if (www.responseCode == 500)
                {
                    leaderboardText.text = "Leaderboard not found.";
                }
                else
                {
                    leaderboardText.text = "Error getting leaderboard.";
                }
            }
            else
            {
                // PHP'den gelen veriyi leaderboardText'e atayýn
                leaderboardText.text = www.downloadHandler.text;
            }
        }
    }
}
