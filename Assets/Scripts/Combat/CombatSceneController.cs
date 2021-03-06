﻿using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatSceneController : MonoBehaviour
{
    public static CombatSceneController Instance { get; set; }
    [SerializeField] private CombatSetDatabase combatSetDatabase;
    [HideInInspector] public List<CombatantModel> combatantModels;

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

    public void ArrangeScene(CombatScenarioName scenario)
    {
        combatantModels = new List<CombatantModel>();

        //Finds the set
        GameObject targetSet = combatSetDatabase.RetrieveSet(CombatScenarioDatabase.Instance.DetermineCombatSet(scenario));

        //Starts the combat music
        MusicManager.Instance.StartCombatMusic(targetSet.GetComponent<CombatSet>().music);

        //Recieves the list of enemyIds
        List<int> enemyModelIds = CombatScenarioDatabase.Instance.IdentifyEnemysForCombatScenario(scenario);

        //Recieves the list of enemy models
        List<GameObject> enemyModels = ModelDatabaseController.Instance.RetrieveEnemyModels(enemyModelIds);

        //Adds enemy models to combatant models list
        foreach (var model in enemyModels)
        {
            combatantModels.Add(new CombatantModel(model, CombatantType.Enemy));
        }

        //place enemies on set
        targetSet.GetComponent<CombatSet>().PlaceEnemies(enemyModels);

        //Recieves the list of ally models
        List<GameObject> allyModels = ModelDatabaseController.Instance.RetrieveAllyModels();

        //Adds ally models to combatant models list
        foreach (var model in allyModels)
        {
            combatantModels.Add(new CombatantModel(model, CombatantType.Ally));
        }

        //place allies on set
        targetSet.GetComponent<CombatSet>().PlaceAllies(allyModels);

        //Recieves the player models
        GameObject playerModel = ModelDatabaseController.Instance.RetrievePlayerModel();

        //Adds the player model to the combatant models list
        combatantModels.Add(new CombatantModel(playerModel, CombatantType.Player));

        //place player on set
        targetSet.GetComponent<CombatSet>().PlacePlayer(playerModel);
    }
}

[Serializable]
public struct CombatantModel
{
    public GameObject charcterModel;
    public CombatantType combatantType;

    public CombatantModel(GameObject charcterModel, CombatantType combatantType)
    {
        this.charcterModel = charcterModel;
        this.combatantType = combatantType;
    }
}