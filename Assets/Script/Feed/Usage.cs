using UnityEngine;
using UnityEngine.UI;

public class Usage : MonoBehaviour
{
    public Button spawnOreButton;
    private RNG_Client rngClient;

    private void Start()
    {
        rngClient = GetComponent<RNG_Client>();
        spawnOreButton.onClick.AddListener(OnSpawnOreButtonClicked);
    }

    private void OnSpawnOreButtonClicked()
    {
        rngClient.SpawnRandomIronOre();
    }
}
