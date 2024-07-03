using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CivicService : MonoBehaviour
{
    private const string CIVIC_API_BASE_URL = "https://api.civic.com/";
    private const string CLIENT_ID = "YOUR_CIVIC_CLIENT_ID";
    private const string CLIENT_SECRET = "YOUR_CIVIC_CLIENT_SECRET";

    public IEnumerator GetCivicToken(string authorizationCode, Action<string> callback)
    {
        string endpoint = $"{CIVIC_API_BASE_URL}oauth/token";
        WWWForm form = new WWWForm();
        form.AddField("client_id", CLIENT_ID);
        form.AddField("client_secret", CLIENT_SECRET);
        form.AddField("grant_type", "authorization_code");
        form.AddField("code", authorizationCode);

        using (UnityWebRequest www = UnityWebRequest.Post(endpoint, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Civic token request failed: " + www.error);
            }
            else
            {
                string jsonResult = www.downloadHandler.text;
                callback(jsonResult);
            }
        }
    }

    public IEnumerator VerifyUser(string accessToken, Action<string> callback)
    {
        string endpoint = $"{CIVIC_API_BASE_URL}scopeRequest/authCode";
        UnityWebRequest www = UnityWebRequest.Get(endpoint);
        www.SetRequestHeader("Authorization", $"Bearer {accessToken}");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Civic verify request failed: " + www.error);
        }
        else
        {
            string jsonResult = www.downloadHandler.text;
            callback(jsonResult);
        }
    }
}
