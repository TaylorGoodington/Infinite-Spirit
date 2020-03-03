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

    //TODO - Write
    public void ArrangeScene(CombatScenarioName scenario)
    {
        //Finds the set
        GameObject targetSet = combatSetDatabase.RetrieveSet(CombatScenarioDatabase.Instance.DetermineCombatSet(scenario));

        //Starts the combat music
        MusicManager.Instance.StartCombatMusic(targetSet.GetComponent<CombatSet>().music);

        //Recieves the list of enemyIds
        List<byte> enemyIds = CombatScenarioDatabase.Instance.IdentifyEnemysForCombatScenario(scenario);

        //Recieves the list of enemy models
        List<GameObject> enemyModels = EnemyModelDatabase.Instance.RetrieveModels(enemyIds);

        //place enemies on set based on number of enemies and positioning requirements if necessary.
        targetSet.GetComponent<CombatSet>().PlaceEnemies(enemyModels);

        //grabs ally models
        //places ally models
        //grabs player model
        //places player model
    }

    private void PlaceEnemyModelsInScene()
    {

    }
}