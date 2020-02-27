using System;
using System.Collections.Generic;
using UnityEngine;

public class CombatSetDatabase : MonoBehaviour
{
    public List<CombatSet> normalSets;
    public List<CombatSet> bossSets;

    public GameObject DetermineSet(CombatController.CombatScenario scenario, MasterControl.Location location)
    {
        CombatSet set = new CombatSet();

        if (scenario == CombatController.CombatScenario.Normal)
        {
            set = normalSets.Find(normalSet => normalSet.location == location);
        }
        else if (scenario == CombatController.CombatScenario.Boss)
        {
            set = bossSets.Find(normalSet => normalSet.location == location);
        }

        return set.setObject;
    }
}

[Serializable]
public struct CombatSet
{
    public MasterControl.Location location;
    public GameObject setObject;
}