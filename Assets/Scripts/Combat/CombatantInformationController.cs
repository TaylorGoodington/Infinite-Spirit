using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatantInformationController : MonoBehaviour
{
    public static CombatantInformationController Instance { get; set; }
    private List<CombatantInformation> combatantsInformation;

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
        combatantsInformation = new List<CombatantInformation>();

        combatantsInformation.Add(new CombatantInformation(PLAYER_CHARACTER_ID, CombatantType.Player, GameData.Instance.playerCoreFirewall, GameData.Instance.playerCompiler, GameData.Instance.playerDefenseMatrix, GameData.Instance.playerPredictiveAlgorithms));

        //add ally information
            //figure out bonus for personality similarities
            //figure out bonus for aquired tree nodes

        //add enemy information
            //figure out scaling bonus for aquired nodes
    }
}

[Serializable]
public class CombatantInformation
{
    public int characterId;
    public CombatantType combatantType;
    public int coreFirewall;
    public int compiler;
    public int defenseMatrix;
    public int predictiveAlgorithms;

    public Dictionary<StatusEffect, float> statusEffects;
    public int targetCombatantId; //Maybe just the array index for combatants in the CombatController
    public Skill[] availableSkills; //Just for enemies???

    public CombatantInformation(int characterId, CombatantType combatantType, int coreFirewall, int compiler, int defenseMatrix, int predictiveAlgorithms)
    {
        this.characterId = characterId;
        this.combatantType = combatantType;
        this.coreFirewall = coreFirewall;
        this.compiler = compiler;
        this.defenseMatrix = defenseMatrix;
        this.predictiveAlgorithms = predictiveAlgorithms;
    }
}