using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatSceneController : MonoBehaviour
{
    public static CombatSceneController Instance { get; set; }
    [SerializeField] private CombatSetDatabase combatSetDatabase;

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
        //Finds the set
        GameObject targetSet = combatSetDatabase.RetrieveSet(CombatScenarioDatabase.Instance.DetermineCombatSet(scenario));

        //Starts the combat music
        MusicManager.Instance.StartCombatMusic(targetSet.GetComponent<CombatSet>().music);

        //Recieves the list of enemyIds
        List<short> enemyIds = CombatScenarioDatabase.Instance.IdentifyEnemysForCombatScenario(scenario);

        //Recieves the list of enemy models
        List<GameObject> enemyModels = ModelDatabaseController.Instance.RetrieveEnemyModels(enemyIds);

        //place enemies on set
        targetSet.GetComponent<CombatSet>().PlaceEnemies(enemyModels);

        //TODO - Define better retrieval process
        //Recieves the list of AllyIds
        List<short> allyIds = GameData.Instance.allyIds;

        //Recieves the list of ally models
        List<GameObject> allyModels = ModelDatabaseController.Instance.RetrieveAllyModels(allyIds);

        //place allies on set
        targetSet.GetComponent<CombatSet>().PlaceAllies(allyModels);

        //TODO - Define better retrieval process
        //Recieves the playerModelId
        short playerModelId = GameData.Instance.playerEquippedSoulId;

        //Recieves the player models
        GameObject playerModel = ModelDatabaseController.Instance.RetrievePlayerModel(playerModelId);

        //place player on set
        targetSet.GetComponent<CombatSet>().PlacePlayer(playerModel);
    }
}