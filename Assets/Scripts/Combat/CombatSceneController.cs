using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSceneController : MonoBehaviour
{
    public static CombatSceneController Instance { get; set; }
    public CombatSet[] normalSets;
    public CombatSet[] bossSets;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {

    }

    //TODO - Write
    public void ArrangeScene()
    {
        byte setId = DetermineSet();
    }

    private byte DetermineSet()
    {
        byte setId = 0;

        if (MasterControl.Instance.playerLocation == MasterControl.Location.Fields)
        {
            setId = (int)MasterControl.Location.Hub_Town;
        }

        return setId;
    }
}

[Serializable]
public struct CombatSet
{
    public MasterControl.Location location;
    public GameObject setObject;
}