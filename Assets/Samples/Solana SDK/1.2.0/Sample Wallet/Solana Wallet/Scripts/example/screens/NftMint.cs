using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Solana.Unity.Metaplex.NFT.Library;
using Solana.Unity.Metaplex.Utilities;
using Solana.Unity.Programs;
using Solana.Unity.Rpc.Builders;
using Solana.Unity.Rpc.Models;
using Solana.Unity.Rpc.Types;
using Solana.Unity.SDK;
using Solana.Unity.Wallet;
using UnityEngine;

public class NftMint : MonoBehaviour
{
    public GameObject success, notsuccess;
    public BinaYerlestirme kaynakmiktar;
    public void MintNft()
    {
        StartMinting().Forget();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        success.SetActive(false); notsuccess.SetActive(false);
    }


    private async UniTask StartMinting()
    {
        Loading.StartLoading();

        // Mint and ATA
        var mint = new Account();
        var associatedTokenAccount = AssociatedTokenAccountProgram
            .DeriveAssociatedTokenAccount(Web3.Account, mint.PublicKey);

        // Define the metadata
        var metadata = new Metadata()
        {
            name = "Digger LV2 NFT",
            symbol = "BACKW",
            uri = "https://orange-secure-bedbug-404.mypinata.cloud/ipfs/QmZcEeTpE2KsgQmLkFWrJDBb3tyQrFRw6W3XenvvfDSSh3",
            sellerFeeBasisPoints = 0,
            creators = new List<Creator> { new(Web3.Account.PublicKey, 100, true) }
        };

        // Prepare the transaction
        var blockHash = await Web3.Rpc.GetLatestBlockHashAsync();
        var minimumRent = await Web3.Rpc.GetMinimumBalanceForRentExemptionAsync(TokenProgram.MintAccountDataSize);
        var transaction = new TransactionBuilder()
            .SetRecentBlockHash(blockHash.Result.Value.Blockhash)
            .SetFeePayer(Web3.Account)
            .AddInstruction(
                SystemProgram.CreateAccount(
                    Web3.Account,
                    mint.PublicKey,
                    minimumRent.Result,
                    TokenProgram.MintAccountDataSize,
                    TokenProgram.ProgramIdKey))
            .AddInstruction(
                TokenProgram.InitializeMint(
                    mint.PublicKey,
                    0,
                    Web3.Account,
                    Web3.Account))
            .AddInstruction(
                AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(
                    Web3.Account,
                    Web3.Account,
                    mint.PublicKey))
            .AddInstruction(
                TokenProgram.MintTo(
                    mint.PublicKey,
                    associatedTokenAccount,
                    1,
                    Web3.Account))
            .AddInstruction(MetadataProgram.CreateMetadataAccount(
                PDALookup.FindMetadataPDA(mint),
                mint.PublicKey,
                Web3.Account,
                Web3.Account,
                Web3.Account.PublicKey,
                metadata,
                TokenStandard.NonFungible,
                true,
                true,
                null,
                metadataVersion: MetadataVersion.V3))
            .AddInstruction(MetadataProgram.CreateMasterEdition(
                    maxSupply: null,
                    masterEditionKey: PDALookup.FindMasterEditionPDA(mint),
                    mintKey: mint,
                    updateAuthorityKey: Web3.Account,
                    mintAuthority: Web3.Account,
                    payer: Web3.Account,
                    metadataKey: PDALookup.FindMetadataPDA(mint),
                    version: CreateMasterEditionVersion.V3
                )
            );
        var tx = Transaction.Deserialize(transaction.Build(new List<Account> { Web3.Account, mint }));

        // Sign and Send the transaction
        var res = await Web3.Wallet.SignAndSendTransaction(tx);

        // Show Confirmation
        if (res?.Result != null)
        {
            await Web3.Rpc.ConfirmTransaction(res.Result, Commitment.Confirmed);
            Debug.Log("Minting succeeded, see transaction at https://explorer.solana.com/tx/"
                      + res.Result + "?cluster=" + Web3.Wallet.RpcCluster.ToString().ToLower());
            success.SetActive(true);

            kaynakmiktar.demirMiktar -= 1000;
            renkdegis();
            upgrade();

            StartCoroutine(wait());
        }

        else
        {
            notsuccess.SetActive(true);
            StartCoroutine(wait());

        }

        Loading.StopLoading();
    }
    public void upgrade()
    {
        foreach (GameObject rootObj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            // Tüm alt objeleriyle birlikte kontrol et
            foreach (Transform child in rootObj.GetComponentsInChildren<Transform>(true))
            {
                // Bina4(Clone) isimli objeleri bul
                if (child.name == "Bina4(Clone)")
                {
                    // ResourceChanger script'ini bul
                    ResourceChanger resourceChanger = child.GetComponent<ResourceChanger>();
                    if (resourceChanger != null)
                    {
                        // ResourceChanger script'i ile ilgili iþlemler burada yapýlabilir
                        Debug.Log("ResourceChanger script found!");
                        // Örneðin, bir metodunu çaðýrabilir veya bir deðiþkenini deðiþtirebilirsiniz

                        resourceChanger.zamanAraligi = 3;
                        resourceChanger.demir = 40;
                        resourceChanger.su = 40;// Örneðin bu þekilde bir metodunu çaðýrabilirsiniz
                    }
                }
            }
        }
    }
    public void renkdegis()
    {
        foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            // Objeyi ve alt objelerini dolaþarak isim kontrolü yap
            foreach (Transform child in obj.GetComponentsInChildren<Transform>(true))
            {
                if (child.name == "Renk") // Objelerin adýný doðru girin
                {
                    // MeshRenderer component'ini al
                    MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                    if (renderer != null && renderer.materials.Length > 2) // En az 3 materyal olduðundan emin ol
                    {
                        // Material.004 ün index'ini bul (bu örnekte 2 olarak varsayýldý)
                        Material myMaterial = renderer.materials[2];

                        // Rengi sarý yap
                        myMaterial.color = Color.yellow;
                    }
                }
            }
        }
    }
}
