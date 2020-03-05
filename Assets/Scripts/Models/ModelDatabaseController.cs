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

    private List<ModelInformation> enemyModels;
    private List<ModelInformation> allyModels;
    private List<ModelInformation> playerModels;

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

    private void Start()
    {
        GenerateEnemyModelList();
        GenerateAllyModelList();
        GeneratePlayerModelList();
    }

    private void GenerateEnemyModelList()
    {
        enemyModels = new List<ModelInformation>();

        for (int i = 0; i < enemyDatabase.childCount; i++)
        {
            GameObject child = enemyDatabase.GetChild(i).gameObject;
            enemyModels.Add(new ModelInformation(child.GetInstanceID(), child.GetComponent<CharacterInformation>().characterId, child));
        }
    }

    private void GenerateAllyModelList()
    {
        allyModels = new List<ModelInformation>();

        for (int i = 0; i < allyDatabase.childCount; i++)
        {
            GameObject child = allyDatabase.GetChild(i).gameObject;
            allyModels.Add(new ModelInformation(child.GetInstanceID(), child.GetComponent<CharacterInformation>().characterId, child));
        }
    }

    private void GeneratePlayerModelList()
    {
        playerModels = new List<ModelInformation>();

        for (int i = 0; i < playerDatabase.childCount; i++)
        {
            GameObject child = playerDatabase.GetChild(i).gameObject;
            playerModels.Add(new ModelInformation(child.GetInstanceID(), child.GetComponent<CharacterInformation>().characterId, child));
        }
    }

    public List<GameObject> RetrieveEnemyModels(List<byte> ids) 
    {
        List<GameObject> models = new List<GameObject>();
        
        //loops through all ids
        for (int i = 0; i < ids.Count; i++)
        {
            //loops through all model info records 
            for (int ii = 0; ii < enemyModels.Count; ii++)
            {
                ModelInformation model = enemyModels[ii];

                if (checkedOutEnemyModels.ContainsKey(model.objectInstanceId) == false && model.characterId == ids[i])
                {
                    models.Add(model.model);
                    checkedOutEnemyModels.Add(model.objectInstanceId, new Vector2(model.model.transform.localPosition.x, model.model.transform.localPosition.y));
                    break;
                }
            }
        }
        return models;
    }

    public List<GameObject> RetrieveAllyModels(List<byte> ids)
    {
        List<GameObject> models = new List<GameObject>();

        //loops through all ids
        for (int i = 0; i < ids.Count; i++)
        {
            //loops through all model info records 
            for (int ii = 0; ii < allyModels.Count; ii++)
            {
                ModelInformation model = allyModels[ii];

                if (checkedOutAllyModels.ContainsKey(model.objectInstanceId) == false && model.characterId == ids[i])
                {
                    models.Add(model.model);
                    checkedOutAllyModels.Add(model.objectInstanceId, new Vector2(model.model.transform.localPosition.x, model.model.transform.localPosition.y));
                    break;
                }
            }
        }
        return models;
    }

    public List<GameObject> RetrievePlayerModels(List<byte> ids)
    {
        List<GameObject> models = new List<GameObject>();

        //loops through all ids
        for (int i = 0; i < ids.Count; i++)
        {
            //loops through all model info records 
            for (int ii = 0; ii < playerModels.Count; ii++)
            {
                ModelInformation model = playerModels[ii];

                if (checkedOutPlayerModels.ContainsKey(model.objectInstanceId) == false && model.characterId == ids[i])
                {
                    models.Add(model.model);
                    checkedOutPlayerModels.Add(model.objectInstanceId, new Vector2(model.model.transform.localPosition.x, model.model.transform.localPosition.y));
                    break;
                }
            }
        }
        return models;
    }
}

[Serializable]
public struct ModelInformation 
{
    public int objectInstanceId;
    public byte characterId;
    public GameObject model;

    public ModelInformation(int instanceId, byte id, GameObject modelObject)
    {
        objectInstanceId = instanceId;
        characterId = id;
        model = modelObject;
    }
}