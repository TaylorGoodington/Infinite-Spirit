using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatScenarioDatabase : MonoBehaviour
{
    public static CombatScenarioDatabase Instance { get; set; }
    private List<CombatScenario> combatScenarios;

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

    private void Start()
    {
        combatScenarios = new List<CombatScenario>();
        combatScenarios.Add(new CombatScenario(CombatScenarioName.Worm_Example, Location.Hub_Town, CombatSetName.Example_1, 1, 1, 1));
        combatScenarios.Add(new CombatScenario(CombatScenarioName.Worm_Example_2, Location.Fields, CombatSetName.Example_1, 1, 1, 0));
        combatScenarios.Add(new CombatScenario(CombatScenarioName.Boss_Example, Location.Test_1, CombatSetName.Example_1, 2, 0, 0));
    }

    public List<int> IdentifyEnemysForCombatScenario(CombatScenarioName scenario)
    {
        List<int> enemyIds = new List<int>();

        CombatScenario combatScenario = combatScenarios.Find(x => x.combatScenarioName == scenario);

        enemyIds.Add(combatScenario.enemy1ModelId);
        enemyIds.Add(combatScenario.enemy2ModelId);
        enemyIds.Add(combatScenario.enemy3ModelId);

        return enemyIds;
    }

    public CombatSetName DetermineCombatSet(CombatScenarioName scenario)
    {
        return combatScenarios.Find(x => x.combatScenarioName == scenario).set;
    }
}

[Serializable]
public class CombatScenario
{
    public CombatScenarioName combatScenarioName;
    public Location combatLocation;
    public CombatSetName set;
    public int enemy1ModelId;
    public int enemy2ModelId;
    public int enemy3ModelId;

    public CombatScenario(CombatScenarioName scenario, Location location, CombatSetName combatSet, int enemy1Id, int enemy2Id, int enemy3Id)
	{
        combatScenarioName = scenario;
        combatLocation = location;
        set = combatSet;
        enemy1ModelId = enemy1Id;
        enemy2ModelId = enemy2Id;
        enemy3ModelId = enemy3Id;
    }
}