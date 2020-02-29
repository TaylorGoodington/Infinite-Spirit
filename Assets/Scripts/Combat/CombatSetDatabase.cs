using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatSetDatabase : MonoBehaviour
{
    public List<CombatSet> combatSets;

    public CombatSet DetermineSet(CombatScenarioName scenario, Location location)
    {
        CombatSet set = new CombatSet();

        set = combatSets.Find(x => x.location == location && x.scenario == scenario);

        return set;
    }
}

[Serializable]
public struct CombatSet
{
    public Location location;
    public CombatScenarioName scenario;
    public GameObject setObject;
    public AudioClip music;
}