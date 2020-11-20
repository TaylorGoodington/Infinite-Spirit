using UnityEngine;
using static Utility;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance { get; set; }

    private bool doesPlayerHaveControl;
    private bool isInCombat;
    private bool isInDigitalWorld;
    private GameDataFile currentFile;
    private InputStates inputState;
    private OverworldController overworldPlayer;

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
        GameData.Instance.InitializeGameData();
        overworldPlayer = GameObject.FindGameObjectWithTag("Overworld_Player").GetComponent<OverworldController>();
        #endregion
    }

    public GameDataFile GetCurrentGameDataFile ()
    {
        return currentFile;
    }

    public InputStates GetCurrentInputState ()
    {
        return inputState;
    }

    public OverworldController GetOverworldPlayer ()
    {
        return overworldPlayer;
    }
}