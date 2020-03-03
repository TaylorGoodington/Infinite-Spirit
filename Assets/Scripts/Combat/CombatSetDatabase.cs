using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatSetDatabase : MonoBehaviour
{
    private List<CombatSetInformation> combatSets;

    private void Start()
    {
        GenerateCombatSetInformation();
    }

    private void GenerateCombatSetInformation()
    {
        combatSets = new List<CombatSetInformation>();

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            combatSets.Add(new CombatSetInformation(child.GetComponent<CombatSet>().setName, child));
        }
    }

    public GameObject RetrieveSet(CombatSetName set)
    {
        return combatSets.Find(x => x.setName == set).set;
    }
}

[Serializable]
public struct CombatSetInformation
{
    public CombatSetName setName;
    public GameObject set;

    public CombatSetInformation(CombatSetName combatSetName, GameObject combatSet)
    {
        setName = combatSetName;
        set = combatSet;
    }
}