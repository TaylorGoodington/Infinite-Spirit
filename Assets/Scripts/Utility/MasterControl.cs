using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance { get; set; }

    #region ReEvaluate Later...
    public bool doesPlayerHaveControl;
    public bool isInCombat;
    public bool isInDigitalWorld;
    public Location playerLocation;
    public List<short> allyIds;
    public short playerEquippedSoulId;
    #endregion

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
        allyIds = new List<short>
        {
            2,
            3
        };
        playerEquippedSoulId = 6;
        #endregion

    }

}