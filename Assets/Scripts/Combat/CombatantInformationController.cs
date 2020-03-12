using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatantInformationController : MonoBehaviour
{
    public static CombatantInformationController Instance { get; set; }
    private CombatantInformation[] combatantsInformation;

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

    public void CombatantInformationInitialization(CombatScenarioName scenario)
    {
        //builds the combatantsInformation array.

        //grab player info from gamedata
            //Initialize Player combat stats + skills
                //class => base stats and skills
                //tree stats => additional stats and skills
                    //skill list that is a combination of class skills list (derrived from the database) and aquired tree skills list
                    //tree skills database
                    //class skills database

        //use scenario to find enemies
        //grab ally info from gamedata
    }
}

[Serializable]
public class CombatantInformation
{
    public Dictionary<StatusEffect, float> statusEffects;

    //Base stats that go unchanged in a combat.
    public byte coreFirewall;
    public byte compiler;
    public byte defenseMatrix;

    public int targetCombatantId; //Maybe just the array index for combatants in the CombatController
    public int[] availableSkills;
}