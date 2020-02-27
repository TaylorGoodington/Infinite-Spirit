using System;
using System.Collections.Generic;
using UnityEngine;
using static Utilitiy;

public class CombatSetDatabase : MonoBehaviour
{
    public List<CombatSet> combatSets;

    public CombatSet DetermineSet(CombatScenario scenario, Location location)
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
    public CombatScenario scenario;
    public GameObject setObject;
    public AudioClip music;
}