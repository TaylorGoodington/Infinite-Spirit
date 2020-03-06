using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

[Serializable]
public class CombatSet : MonoBehaviour
{
    public CombatSetName setName;
    public AudioClip music;
    public Transform[] enemyPositions;
    public Transform[] allyPositions;
    public Transform playerPosition;

    public void PlaceEnemies(List<GameObject> enemyModels)
    {
        for (int i = 0; i < enemyModels.Count; i++)
        {
            enemyModels[i].transform.parent = enemyPositions[i];
            enemyModels[i].transform.localPosition = Vector3.zero;
        }
    }

    public void PlaceAllies(List<GameObject> models)
    {
        for (int i = 0; i < models.Count; i++)
        {
            models[i].transform.parent = allyPositions[i];
            models[i].transform.localPosition = Vector3.zero;
        }
    }

    public void PlacePlayer(GameObject model)
    {
        model.transform.parent = playerPosition;
        model.transform.localPosition = Vector3.zero;
    }
}