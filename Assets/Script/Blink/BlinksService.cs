using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Solana.Unity.SDK;
using Solana.Unity.Wallet;
using Solana.Unity.Programs;
using Solana.Unity.Rpc;
using Solana.Unity.Rpc.Models;

public class BlinksService : MonoBehaviour
{
    private static readonly IRpcClient rpcClient = ClientFactory.GetClient(Cluster.DevNet);
    private Account player;
    private const string BLINKS_URL = "https://api.solanablinks.com/"; 
    private const string API_KEY = "YOUR_API_KEY_HERE"; 

    public GameObject ironOrePrefab;

    public void SetPlayer(Account account)
    {
        player = account;
    }

    public void SpawnRandomIronOre(Miner miner)
    {
        StartCoroutine(FetchRandomNumber(miner, OnRandomNumberReceived));
    }

    private IEnumerator FetchRandomNumber(Miner miner, Action<float, Miner> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(BLINKS_URL + "random");
        www.SetRequestHeader("Authorization", $"Bearer {API_KEY}");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Request failed: " + www.error);
        }
        else
        {
            string jsonResult = www.downloadHandler.text;
            float randomNumber = float.Parse(jsonResult); 
            callback(randomNumber, miner);
        }
    }

    private void OnRandomNumberReceived(float randomNumber, Miner miner)
    {
        float randomX = randomNumber % 100; 
        float randomZ = (randomNumber * 1.5f) % 100; 
        Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);


        float miningCost = miner.level * 10; 
        Debug.Log($"Mining cost for miner level {miner.level}: {miningCost}");

        Instantiate(ironOrePrefab, spawnPosition, Quaternion.identity);
    }
}
