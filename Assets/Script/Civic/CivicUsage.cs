using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    private CivicKYCManager kycManager;

    private void Start()
    {
        kycManager = GetComponent<CivicKYCManager>();
    }

    public void OnStartKYCButtonClicked()
    {
        string authorizationCode = "USER_AUTHORIZATION_CODE"; 
        kycManager.StartKYCProcess(authorizationCode);
    }
}
