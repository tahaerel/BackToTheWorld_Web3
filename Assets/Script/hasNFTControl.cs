using TMPro;
using UnityEngine;
using System.Linq;
using Cysharp.Threading.Tasks;
using Solana.Unity.Rpc.Models;
using Solana.Unity.SDK;
using Solana.Unity.Rpc.Types;

public class hasNFTControl : MonoBehaviour
{
    public static bool hasnft;
    private async void Start()
    {
        await CheckForNftAsync("2myEdmJ2Y6WGrVMQAeWqqBhVx46gF4v7r9tY5MjM3gDq"); 
    }

    private async UniTask CheckForNftAsync(string nftName)
    {
        if (!Web3.Instance)
        {
            Debug.LogError("Kullanýcý giriþ yapmamýþ!");
            return;
        }

        var tokens = await Web3.Wallet.GetTokenAccounts(Commitment.Confirmed);
        if (tokens == null)
        {
            Debug.LogError("NFT bilgisi alýnamadý.");
            return;
        }

        bool hasNft = tokens.Any(t => t.Account.Data.Parsed.Info.Mint.ToString() == nftName);
        if (hasNft)
        {
            nftEnable(); 
        }
        else
        {
            Debug.Log("NFT yok");
        }
    }

    private void nftEnable()
    {
       
        Debug.Log("NFT mevcut ve nftEnable fonksiyonu çalýþtý.");
        hasnft = true;
    }
}
