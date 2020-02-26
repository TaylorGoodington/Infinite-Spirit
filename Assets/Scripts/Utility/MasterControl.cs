using UnityEngine;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance { get; set; }

    public bool doesPlayerHaveControl;
    public bool isInCombat;
    public bool isInDigitalWorld;
    public Location playerLocation;

    public enum Location
    {
        Hub_Town = 0,
        Fields = 1
    }

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
        #region Testing
        doesPlayerHaveControl = false;
        isInCombat = false;
        isInDigitalWorld = false;
        playerLocation = Location.Hub_Town;
        #endregion

    }

}