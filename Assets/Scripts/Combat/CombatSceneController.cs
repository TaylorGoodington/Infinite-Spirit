using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatSceneController : MonoBehaviour
{
    public static CombatSceneController Instance { get; set; }
    [SerializeField] private CombatSetDatabase combatSetDatabase;

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

    public Dictionary<int,short> ArrangeScene(CombatScenarioName scenario)
    {
        //Finds the set
        GameObject targetSet = combatSetDatabase.RetrieveSet(CombatScenarioDatabase.Instance.DetermineCombatSet(scenario));

        //Starts the combat music
        MusicManager.Instance.StartCombatMusic(targetSet.GetComponent<CombatSet>().music);

        //Recieves the list of enemyIds
        List<short> enemyIds = CombatScenarioDatabase.Instance.IdentifyEnemysForCombatScenario(scenario);

        //Recieves the list of enemy models
        List<GameObject> enemyModels = ModelDatabaseController.Instance.RetrieveEnemyModels(enemyIds);

        //place enemies on set
        targetSet.GetComponent<CombatSet>().PlaceEnemies(enemyModels);

        //Recieves the list of AllyIds
        List<short> allyIds = GameData.Instance.allyIds;

        //Recieves the list of ally models
        List<GameObject> allyModels = ModelDatabaseController.Instance.RetrieveAllyModels(allyIds);

        //place allies on set
        targetSet.GetComponent<CombatSet>().PlaceAllies(allyModels);

        //Recieves the playerModelId
        short playerModelId = GameData.Instance.playerEquippedSoulParadigmId;

        //Recieves the player models
        GameObject playerModel = ModelDatabaseController.Instance.RetrievePlayerModel(playerModelId);

        //place player on set
        targetSet.GetComponent<CombatSet>().PlacePlayer(playerModel);

        //TODO Finish...
        //passes back dictionary of objectinstanceids and model ids.
        Dictionary<int, short> combatantModelInfo = new Dictionary<int, short>();

        return combatantModelInfo;
    }
}