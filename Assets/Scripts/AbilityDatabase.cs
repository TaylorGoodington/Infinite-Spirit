using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDatabase : MonoBehaviour
{
    public static List<Abilities> abilityDatabase;

    //damage and defense are percentages so 0 to 1 in most cases.
    void Start()
    {
        abilityDatabase = new List<Abilities>
        {
            new Abilities(0, "Soldier", "The way of the sword", 3, 5, 4, 1, 3, 2, 6, 1)
        };
    }
}