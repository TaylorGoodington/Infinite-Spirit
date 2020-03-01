using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelDatabase : MonoBehaviour
{
    public static EnemyModelDatabase Instance { get; set; }
    private List<EnemyModelInformation> enemyModels;
    private List<ModelRecord> modelRecords;

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
        modelRecords = new List<ModelRecord>();
        //makes a list of all the models at run time.
        //Done by searching the enemy script for the enemyId and getting the instanceId;
        enemyModels = new List<EnemyModelInformation>();

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            //Change second param to draw from enemy script...
            enemyModels.Add(new EnemyModelInformation(child.GetInstanceID(), 0, child, false));
        }
    }

    public List<GameObject> RetrieveModels(List<byte> ids) 
    {
        List<GameObject> models = new List<GameObject>();
        
        for (int i = 0; i < ids.Count; i++)
        {
            for (int ii = 0; ii < enemyModels.Count; ii++)
            {
                if (enemyModels[ii].modelEnemyId == ids[i] && enemyModels[ii].isCheckedOut == false)
                {
                    EnemyModelInformation newModel = new EnemyModelInformation(enemyModels[ii].objectInstanceId, enemyModels[ii].modelEnemyId, enemyModels[ii].enemyModel, true);
                    enemyModels[ii] = newModel;
                    models.Add(enemyModels[ii].enemyModel);

                    modelRecords.Add(new ModelRecord(enemyModels[ii].objectInstanceId, new Vector2(enemyModels[ii].enemyModel.transform.localPosition.x, enemyModels[ii].enemyModel.transform.localPosition.y)));
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
    public bool isCheckedOut;
    public GameObject enemyModel;

    public EnemyModelInformation(int instanceId, byte enemyId, GameObject model, bool checkedOut)
    {
        objectInstanceId = instanceId;
        modelEnemyId = enemyId;
        enemyModel = model;
        isCheckedOut = checkedOut;
    }
}

[Serializable]
public struct ModelRecord
{
    public int objectInstanceId;
    public Vector2 originalCoordinates;

    public ModelRecord(int instanceId, Vector2 coordinates)
    {
        objectInstanceId = instanceId;
        originalCoordinates = coordinates;
    }
}