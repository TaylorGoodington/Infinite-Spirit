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
        combatScenarios.Add(new CombatScenario(CombatScenarioName.Worm_Example, Location.Hub_Town, 1, 1, 1));
    }

    public List<byte> IdentifyEnemysForCombatScenario(CombatScenarioName scenario)
    {
        List<byte> enemyIds = new List<byte>();

        CombatScenario combatScenario = combatScenarios.Find(x => x.combatScenarioName == scenario);

        enemyIds.Add(combatScenario.combatEnemy1Id);
        enemyIds.Add(combatScenario.combatEnemy2Id);
        enemyIds.Add(combatScenario.combatEnemy3Id);

        return enemyIds;
    }
}

[Serializable]
public class CombatScenario
{
    public CombatScenarioName combatScenarioName;
    public Location combatLocation;
    public byte combatEnemy1Id;
    public byte combatEnemy2Id;
    public byte combatEnemy3Id;

    public CombatScenario(CombatScenarioName scenario, Location location, byte enemy1Id, byte enemy2Id, byte enemy3Id)
	{
        combatScenarioName = scenario;
        combatLocation = location;
        combatEnemy1Id = enemy1Id;
        combatEnemy2Id = enemy2Id;
        combatEnemy3Id = enemy3Id;
    }
}