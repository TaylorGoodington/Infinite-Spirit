using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelDatabase : MonoBehaviour
{
    public static EnemyModelDatabase Instance { get; set; }
    private List<EnemyModelInformation> enemyModels;

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
            enemyModels.Add(new EnemyModelInformation(child.GetInstanceID(), 0, false));
        }
    }

    public List<GameObject> RetrieveModels(List<byte> ids) 
    {
        List<GameObject> models = new List<GameObject>();
        //runs through the list and grabs the models.
        //when checked out, will make a record of their initial location, so when they are returned they can be stored correcty.
        //Done by using.getinstanceid() on the gameobject to get the id and records that and the vector.
        for (int i = 0; i < ids.Count; i++)
        {
            EnemyModelInformation model = enemyModels.Find(x => x.modelEnemyId == ids[i] && x.isCheckedOut == false);
            //check out model
        }

        return models;
    }
}

public struct EnemyModelInformation 
{
    public int objectInstanceId;
    public byte modelEnemyId;
    public bool isCheckedOut;

    public EnemyModelInformation(int instanceId, byte enemyId, bool checkedOut)
    {
        objectInstanceId = instanceId;
        modelEnemyId = enemyId;
        isCheckedOut = checkedOut;
    }
}