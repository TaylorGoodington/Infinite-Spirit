using UnityEngine;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance { get; set; }

    public bool doesPlayerHaveControl;
    public bool isInCombat;
    public bool isInDigitalWorld;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        doesPlayerHaveControl = false;
        isInCombat = false;
        isInDigitalWorld = false;
    }

}