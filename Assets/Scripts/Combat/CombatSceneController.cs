using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSceneController : MonoBehaviour
{
    public static CombatSceneController Instance { get; set; }
    private CombatSetDatabase combatSetDatabase;

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
        combatSetDatabase = GetComponentInChildren<CombatSetDatabase>();
    }

    //TODO - Write
    public void ArrangeScene(CombatController.CombatScenario scenario, MasterControl.Location location)
    {
        GameObject targetSet = combatSetDatabase.DetermineSet(scenario, location);
        //grab enemy models
        //place enemies on set based on number of enemies and positioning requirements if necessary.
        //grabs ally models
        //places ally models
        //grabs player model
        //places player model
    }

    
}