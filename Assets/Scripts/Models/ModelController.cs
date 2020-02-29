using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class ModelController : MonoBehaviour
{
    public static ModelController Instance { get; set; }
    [SerializeField] private EnemyModelDatabase enemyDatabase;
    [SerializeField] private AllyModelDatabase allyDatabase;
    [SerializeField] private PlayerModelDatabase playerDatabase;

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

    public List<GameObject> RetrieveEnemyCombatModels(List<byte> ids)
    {
        List<GameObject> enemyModels = new List<GameObject>();

        //gets the models from the enemy model database

        return enemyModels;
    }
}