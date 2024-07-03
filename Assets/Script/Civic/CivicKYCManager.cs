using System.Collections;
using UnityEngine;

public class CivicKYCManager : MonoBehaviour
{
    private CivicService civicService;

    private void Start()
    {
        civicService = GetComponent<CivicService>();
    }

    public void StartKYCProcess(string authorizationCode)
    {
        StartCoroutine(civicService.GetCivicToken(authorizationCode, OnTokenReceived));
    }

    private void OnTokenReceived(string token)
    {
        StartCoroutine(civicService.VerifyUser(token, OnUserVerified));
    }

    private void OnUserVerified(string result)
    {
        Debug.Log("User verification result: " + result);
        //Leaderboard save
    }
}
