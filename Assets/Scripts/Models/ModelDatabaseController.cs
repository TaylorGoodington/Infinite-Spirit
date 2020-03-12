using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class ModelDatabaseController : MonoBehaviour
{
    public static ModelDatabaseController Instance { get; set; }

    public Transform enemyDatabase;
    public Transform allyDatabase;
    public Transform playerDatabase;
    public List<ModelIdInformation> modelInformationDatabase;

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
        modelInformationDatabase = new List<ModelIdInformation>()
        {
            new ModelIdInformation(1, 1, null),
            new ModelIdInformation(2, 4, null),
            new ModelIdInformation(3, 5, null),
            new ModelIdInformation(4, 2, Paradigm.Soldier),
            new ModelIdInformation(5, 3, Paradigm.Bishop),
            new ModelIdInformation(6, 6, Paradigm.Mage),
            new ModelIdInformation(7, 1, null),
            new ModelIdInformation(8, 1, null),
            new ModelIdInformation(9, 6, Paradigm.Sorceror)
        };
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
                ModelId model = enemyDatabase.transform.GetChild(ii).GetComponent<ModelId>();

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

    public List<GameObject> RetrieveAllyModels()
    {
        List<GameObject> models = new List<GameObject>();
        List<short> modelIds = new List<short>();

        foreach (var allyId in GameData.Instance.currentPartyMemberCharacterIds)
        {
            Paradigm allyParadigm = GameData.Instance.allyEquippedSouldParadigms[allyId];
            modelIds.Add(modelInformationDatabase.Find(x => x.characterId == allyId && x.paradigm == allyParadigm).modelId);
        }
        //loops through all ids
        for (int i = 0; i < modelIds.Count; i++)
        {
            //loops through all model info records 
            for (int ii = 0; ii < allyDatabase.transform.childCount; ii++)
            {
                ModelId model = allyDatabase.transform.GetChild(ii).GetComponent<ModelId>();

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

    public GameObject RetrievePlayerModel()
    {
        GameObject playerModel = null;
        short playerModelId = modelInformationDatabase.Find(x => x.characterId == PLAYER_CHARACTER_ID && x.paradigm == GameData.Instance.playerEquippedSoulParadigm).modelId;

        for (int ii = 0; ii < playerDatabase.transform.childCount; ii++)
        {
            ModelId model = playerDatabase.transform.GetChild(ii).GetComponent<ModelId>();

            if (checkedOutPlayerModels.ContainsKey(model.GetInstanceID()) == false && model.modelId == playerModelId)
            {
                checkedOutPlayerModels.Add(model.modelId, new Vector2(model.transform.localPosition.x, model.transform.localPosition.y));
                playerModel = model.gameObject;
                break;
            }
        }
        return playerModel;
    }
}

public struct ModelIdInformation
{
    public short modelId;
    public short characterId;
    public Paradigm? paradigm;

    public ModelIdInformation(short modelId, short characterId, Paradigm? paradigm)
    {
        this.modelId = modelId;
        this.characterId = characterId;
        this.paradigm = paradigm;
    }
}