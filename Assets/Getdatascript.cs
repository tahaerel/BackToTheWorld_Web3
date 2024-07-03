using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Getdatascript : MonoBehaviour
{
    private const string phpgetURL = "https://www.pushup.games/get_leaderboard.php"; // PHP dosyanýzýn URL'si

    public TextMeshProUGUI leaderboardText;

    private void Start()
    {
        StartCoroutine(GetLeaderboard());
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
