using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class ModelDatabaseController : MonoBehaviour
{
    public static ModelDatabaseController Instance { get; set; }

    public Transform enemyDatabase;
    public Transform allyDatabase;
    public Transform playerDatabase;

    private Dictionary<int, Vector2> checkedOutEnemyModels = new Dictionary<int, Vector2>();
    private Dictionary<int, Vector2> checkedOutAllyModels = new Dictionary<int, Vector2>();
    private Dictionary<int, Vector2> checkedOutPlayerModels = new Dictionary<int, Vector2>();

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

    public List<GameObject> RetrieveEnemyModels(List<short> modelIds) 
    {
        List<GameObject> models = new List<GameObject>();
        
        //loops through all ids
        for (int i = 0; i < modelIds.Count; i++)
        {
            //loops through all model info records 
            for (int ii = 0; ii < enemyDatabase.transform.childCount; ii++)
            {
                ModelInformation model = enemyDatabase.transform.GetChild(ii).GetComponent<ModelInformation>();

                if (checkedOutEnemyModels.ContainsKey(model.GetInstanceID()) == false && model.modelId == modelIds[i])
                {
                    models.Add(model.gameObject);
                    checkedOutEnemyModels.Add(model.GetInstanceID(), new Vector2(model.transform.localPosition.x, model.transform.localPosition.y));
                    break;
                }
            }
        }
        return models;
    }

    public List<GameObject> RetrieveAllyModels(List<short> modelIds)
    {
        List<GameObject> models = new List<GameObject>();

        //loops through all ids
        for (int i = 0; i < modelIds.Count; i++)
        {
            //loops through all model info records 
            for (int ii = 0; ii < allyDatabase.transform.childCount; ii++)
            {
                ModelInformation model = allyDatabase.transform.GetChild(ii).GetComponent<ModelInformation>();

                if (checkedOutAllyModels.ContainsKey(model.GetInstanceID()) == false && model.modelId == modelIds[i])
                {
                    models.Add(model.gameObject);
                    checkedOutAllyModels.Add(model.GetInstanceID(), new Vector2(model.transform.localPosition.x, model.transform.localPosition.y));
                    break;
                }
            }
        }
        return models;
    }

    public GameObject RetrievePlayerModel(short id)
    {
        GameObject playerModel = null;

        for (int ii = 0; ii < playerDatabase.transform.childCount; ii++)
        {
            ModelInformation model = playerDatabase.transform.GetChild(ii).GetComponent<ModelInformation>();

            if (checkedOutPlayerModels.ContainsKey(model.GetInstanceID()) == false && model.modelId == id)
            {
                checkedOutPlayerModels.Add(model.modelId, new Vector2(model.transform.localPosition.x, model.transform.localPosition.y));
                playerModel = model.gameObject;
                break;
            }
        }
        return playerModel;
    }
}