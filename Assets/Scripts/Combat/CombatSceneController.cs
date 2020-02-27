using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilitiy;

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
    public void ArrangeScene(CombatScenario scenario, Location location)
    {
        CombatSet targetSet = combatSetDatabase.DetermineSet(scenario, location);
        MusicManager.Instance.StartCombatMusic(targetSet.music);
        List<EnemyModel> enemyModels = ModelController.Instance.DetermineEnemies(scenario, location);
        //grab enemy models
        //place enemies on set based on number of enemies and positioning requirements if necessary.
        //grabs ally models
        //places ally models
        //grabs player model
        //places player model
    }
}