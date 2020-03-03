using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelDatabase : MonoBehaviour
{
    public static EnemyModelDatabase Instance { get; set; }
    private List<EnemyModelInformation> enemyModels;
    private Dictionary<int, Vector2> checkedOutModels = new Dictionary<int, Vector2>();

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
        //makes a list of all the models at run time.
        //Done by searching the enemy script for the enemyId and getting the instanceId;
        enemyModels = new List<EnemyModelInformation>();

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            //Change second param to draw from enemy script...
            enemyModels.Add(new EnemyModelInformation(child.GetInstanceID(), child.GetComponent<EnemyBase>().id, child));
        }
    }

    public List<GameObject> RetrieveModels(List<byte> ids) 
    {
        List<GameObject> models = new List<GameObject>();
        
        //loops through all ids
        for (int i = 0; i < ids.Count; i++)
        {
            //loops through all model info records 
            for (int ii = 0; ii < enemyModels.Count; ii++)
            {
                EnemyModelInformation model = enemyModels[ii];

                if (checkedOutModels.ContainsKey(model.objectInstanceId) == false && model.modelEnemyId == ids[i])
                {
                    models.Add(model.enemyModel);
                    checkedOutModels.Add(model.objectInstanceId, new Vector2(model.enemyModel.transform.localPosition.x, model.enemyModel.transform.localPosition.y));
                    break;
                }
            }
        }
        return models;
    }
}

[Serializable]
public struct EnemyModelInformation 
{
    public int objectInstanceId;
    public byte modelEnemyId;
    public GameObject enemyModel;

    public EnemyModelInformation(int instanceId, byte enemyId, GameObject model)
    {
        objectInstanceId = instanceId;
        modelEnemyId = enemyId;
        enemyModel = model;
    }
}