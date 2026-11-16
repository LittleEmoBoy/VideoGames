using UnityEngine;
using Vuforia;

public class CloudManager : MonoBehaviour
{
    [SerializeField] private CloudRecoBehaviour cloudRecoBehaviour;
    [SerializeField] private GameObject[] targets;
    private bool isScanning;

    private void Awake()
    {
        cloudRecoBehaviour.RegisterOnInitializedEventHandler(OnInitialized);
        cloudRecoBehaviour.RegisterOnStateChangedEventHandler(OnStateChanged);
        cloudRecoBehaviour.RegisterOnNewSearchResultEventHandler(OnNewSearchResult);

    }

    private void OnDestroy()
    {
        cloudRecoBehaviour.UnregisterOnInitializedEventHandler(OnInitialized);
        cloudRecoBehaviour.UnregisterOnStateChangedEventHandler(OnStateChanged);
        cloudRecoBehaviour.UnregisterOnNewSearchResultEventHandler(OnNewSearchResult);
    }

    private void OnInitialized(CloudRecoBehaviour cloudRecoBehaviour)
    {
        Debug.Log("El cloud se ha inicializado");
    }

    private void OnStateChanged(bool scanning)
    {
        isScanning = scanning;
        if (isScanning)
        {
            Debug.Log("El cloud está escanenando");
        }
    }

    private void OnNewSearchResult(CloudRecoBehaviour.CloudRecoSearchResult result)
    {
        foreach (var target in targets) {
            if (result.TargetName == target.gameObject.name)
            {
                cloudRecoBehaviour.EnableObservers(result, target.gameObject);
            }
        }
    }
}
