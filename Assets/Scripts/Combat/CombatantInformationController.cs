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

        foreach (int ally in GameData.Instance.currentPartyMemberCharacterIds)
        {
            //grab stats from equipped soul paradigm via id in gamedata-equipedAllyParadigms and pull through soul paradigm database

            if (DoesAllyGetPersonalityBonus(ally))
            {

            }
            else
            {

            }

            //figure out bonus for aquired tree nodes

        }

        //add enemy information
        //figure out scaling bonus for aquired nodes
    }

    private bool DoesAllyGetPersonalityBonus (int allyCharacterId)
    {
        bool receiveBonus = false;
        float averageSimilarity;

        #region Q1
        float playerQ1_1 = GameData.Instance.playerPatience;
        float playerQ1_2 = GameData.Instance.playerSomething;
        float similarityQ1_1;
        float allyQ1_1 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].patience;
        float allyQ1_2 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].something;
        float similarityQ1_2;

        if (playerQ1_1 < allyQ1_1)
        {
            similarityQ1_1 = playerQ1_1 / allyQ1_1;
        }
        else
        {
            similarityQ1_1 = allyQ1_1 / playerQ1_1;
        }

        if (playerQ1_2 < allyQ1_2)
        {
            similarityQ1_2 = playerQ1_2 / allyQ1_2;
        }
        else
        {
            similarityQ1_2 = allyQ1_2 / playerQ1_2;
        }

        float similarityQ1 = similarityQ1_1 * similarityQ1_2;
        #endregion

        #region Q2
        float playerQ2_1 = GameData.Instance.playerSomething;
        float playerQ2_2 = GameData.Instance.playerCunning;
        float similarityQ2_1;
        float allyQ2_1 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].something;
        float allyQ2_2 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].cunning;
        float similarityQ2_2;

        if (playerQ2_1 < allyQ2_1)
        {
            similarityQ2_1 = playerQ2_1 / allyQ2_1;
        }
        else
        {
            similarityQ2_1 = allyQ2_1 / playerQ2_1;
        }

        if (playerQ2_2 < allyQ2_2)
        {
            similarityQ2_2 = playerQ2_2 / allyQ2_2;
        }
        else
        {
            similarityQ2_2 = allyQ2_2 / playerQ2_2;
        }

        float similarityQ2 = similarityQ2_1 * similarityQ2_2;
        #endregion

        #region Q3
        float playerQ3_1 = GameData.Instance.playerCunning;
        float playerQ3_2 = GameData.Instance.playerLogical;
        float similarityQ3_1;
        float allyQ3_1 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].cunning;
        float allyQ3_2 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].logical;
        float similarityQ3_2;

        if (playerQ3_1 < allyQ3_1)
        {
            similarityQ3_1 = playerQ3_1 / allyQ3_1;
        }
        else
        {
            similarityQ3_1 = allyQ3_1 / playerQ3_1;
        }

        if (playerQ3_2 < allyQ3_2)
        {
            similarityQ3_2 = playerQ3_2 / allyQ3_2;
        }
        else
        {
            similarityQ3_2 = allyQ3_2 / playerQ3_2;
        }

        float similarityQ3 = similarityQ3_1 * similarityQ3_2;
        #endregion

        #region Q4
        float playerQ4_1 = GameData.Instance.playerLogical;
        float playerQ4_2 = GameData.Instance.playerKindness;
        float similarityQ4_1;
        float allyQ4_1 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].logical;
        float allyQ4_2 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].kindness;
        float similarityQ4_2;

        if (playerQ4_1 < allyQ4_1)
        {
            similarityQ4_1 = playerQ4_1 / allyQ4_1;
        }
        else
        {
            similarityQ4_1 = allyQ4_1 / playerQ4_1;
        }

        if (playerQ4_2 < allyQ4_2)
        {
            similarityQ4_2 = playerQ4_2 / allyQ4_2;
        }
        else
        {
            similarityQ4_2 = allyQ4_2 / playerQ4_2;
        }

        float similarityQ4 = similarityQ4_1 * similarityQ4_2;
        #endregion

        #region Q5
        float playerQ5_1 = GameData.Instance.playerKindness;
        float playerQ5_2 = GameData.Instance.playerCharisma;
        float similarityQ5_1;
        float allyQ5_1 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].kindness;
        float allyQ5_2 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].charisma;
        float similarityQ5_2;

        if (playerQ5_1 < allyQ5_1)
        {
            similarityQ5_1 = playerQ5_1 / allyQ5_1;
        }
        else
        {
            similarityQ5_1 = allyQ5_1 / playerQ5_1;
        }

        if (playerQ5_2 < allyQ5_2)
        {
            similarityQ5_2 = playerQ5_2 / allyQ5_2;
        }
        else
        {
            similarityQ5_2 = allyQ5_2 / playerQ5_2;
        }

        float similarityQ5 = similarityQ5_1 * similarityQ5_2;
        #endregion

        #region Q6
        float playerQ6_1 = GameData.Instance.playerCharisma;
        float playerQ6_2 = GameData.Instance.playerPatience;
        float similarityQ6_1;
        float allyQ6_1 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].charisma;
        float allyQ6_2 = AllyPersonalityDatabase.Instance.AllyPersonalities[allyCharacterId].patience;
        float similarityQ6_2;

        if (playerQ6_1 < allyQ6_1)
        {
            similarityQ6_1 = playerQ6_1 / allyQ6_1;
        }
        else
        {
            similarityQ6_1 = allyQ6_1 / playerQ6_1;
        }

        if (playerQ6_2 < allyQ6_2)
        {
            similarityQ6_2 = playerQ6_2 / allyQ6_2;
        }
        else
        {
            similarityQ6_2 = allyQ6_2 / playerQ6_2;
        }

        float similarityQ6 = similarityQ6_1 * similarityQ6_2;
        #endregion

        averageSimilarity = (similarityQ1 + similarityQ2 + similarityQ3 + similarityQ4 + similarityQ5 + similarityQ6) / 6;

        if (averageSimilarity >= PERSONALITY_BONUS_THRESHOLD)
        {
            receiveBonus = true;
        }

        return receiveBonus;
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