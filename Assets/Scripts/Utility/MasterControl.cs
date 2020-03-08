using UnityEngine;
using static Utility;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance { get; set; }

    public bool doesPlayerHaveControl;
    public bool isInCombat;
    public bool isInDigitalWorld;
    [HideInInspector] public GameDataFile currentFile;

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
        currentFile = GameDataFile.Aplha;
        GameData.Instance.InititalizeGameData();
        #endregion
    }
}