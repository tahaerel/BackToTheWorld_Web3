using Solana.Unity.SDK;
using Solana.Unity.Wallet;
using UnityEngine;
using UnityEngine.UI;

public class BlinkUsage : MonoBehaviour
{
    public Button spawnOreButton;
    private BlinksService blinksService;
    private Miner selectedMiner;

    private void Start()
    {
        blinksService = GetComponent<BlinksService>();
        spawnOreButton.onClick.AddListener(OnSpawnOreButtonClicked);

        selectedMiner = new Miner(level: 5); 
    }

    private void OnSpawnOreButtonClicked()
    {
        blinksService.SpawnRandomIronOre(selectedMiner);
    }

    private void OnEnable()
    {
        Web3.OnLogin += OnLogin;
    }

    private void OnDisable()
    {
        Web3.OnLogin -= OnLogin;
    }

    private void OnLogin(Account account)
    {
        blinksService.SetPlayer(account);
    }
}
