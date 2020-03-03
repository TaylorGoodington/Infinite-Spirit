using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

[Serializable]
public class CombatSet : MonoBehaviour
{
    public CombatSetName setName;
    public AudioClip music;
    public GameObject[] enemyPositions;

    public void PlaceEnemies(List<GameObject> enemyModels)
    {
        for (int i = 0; i < enemyModels.Count; i++)
        {
            enemyModels[i].transform.parent = enemyPositions[i].transform;
            enemyModels[i].transform.localPosition = Vector3.zero;
        }
    }
}