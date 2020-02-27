using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilitiy;

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

    public List<EnemyModel> DetermineEnemies (CombatScenario scenario, Location location)
    {
        List<EnemyModel> enemies = new List<EnemyModel>();



        return enemies;
    }
}