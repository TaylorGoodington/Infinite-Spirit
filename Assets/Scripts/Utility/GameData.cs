using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static Utility;

//The idea behind the game data is to load all three files at once and only use the data from the selected file to play the game. This is done by updating
//the public versions of each variable with the corresponding GameDataFile.
//Read method only pulls in the data from the file, initialize file is what sets up the game for play.

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; set; }

    #region Player Data
    public List<TreeNode> aquiredTreeNodes;
    private List<TreeNode> Alpha_AquiredTreeNodes;
    private List<TreeNode> Beta_AquiredTreeNodes;
    private List<TreeNode> Omega_AquiredTreeNodes;

    public Location playerLocation;
    private Location Alpha_PlayerLocation;
    private Location Beta_PlayerLocation;
    private Location Omega_PlayerLocation;

    public Paradigm playerEquippedSoulParadigm;
    private Paradigm Alpha_PlayerEquippedSoulParadigm;
    private Paradigm Beta_PlayerEquippedSoulParadigm;
    private Paradigm Omega_PlayerEquippedSoulParadigm;

    #region Stats
    public int playerCoreFirewall;
    private int Alpha_PlayerCoreFirewall;
    private int Beta_PlayerCoreFirewall;
    private int Omega_PlayerCoreFirewall;

    public int playerCompiler;
    private int Alpha_PlayerCompiler;
    private int Beta_PlayerCompiler;
    private int Omega_PlayerCompiler;

    public int playerDefenseMatrix;
    private int Alpha_PlayerDefenseMatrix;
    private int Beta_PlayerDefenseMatrix;
    private int Omega_PlayerDefenseMatrix;

    public int playerPredictiveAlgorithms;
    private int Alpha_PlayerPredictiveAlgorithms;
    private int Beta_PlayerPredictiveAlgorithms;
    private int Omega_PlayerPredictiveAlgorithms;
    #endregion Stats

    #region Personality Values
    public float playerPatience;
    private float Alpha_PlayerPatience;
    private float Beta_PlayerPatience;
    private float Omega_PlayerPatience;

    public float playerSomething;
    private float Alpha_PlayerSomething;
    private float Beta_PlayerSomething;
    private float Omega_PlayerSomething;

    public float playerCunning;
    private float Alpha_PlayerCunning;
    private float Beta_PlayerCunning;
    private float Omega_PlayerCunning;

    public float playerLogical;
    private float Alpha_PlayerLogical;
    private float Beta_PlayerLogical;
    private float Omega_PlayerLogical;

    public float playerKindness;
    private float Alpha_PlayerKindness;
    private float Beta_PlayerKindness;
    private float Omega_PlayerKindness;

    public float playerCharisma;
    private float Alpha_PlayerCharisma;
    private float Beta_PlayerCharisma;
    private float Omega_PlayerCharisma;
    #endregion Personality Values

    public List<Skill> playerSkills;
    #endregion Player Data

    #region Ally Data
    //ally: potential party members, current party members, (all, unlocked or not) ally personality data, (all, unlocked or not) allies equipped soul paradigm
    public List<int> potentialPartyMemberCharacterIds;
    private List<int> Alpha_PotentialPartyMemberCharacterIds;
    private List<int> Beta_PotentialPartyMemberCharacterIds;
    private List<int> Omega_PotentialPartyMemberCharacterIds;

    public List<int> currentPartyMemberCharacterIds;
    private List<int> Alpha_CurrentPartyMemberCharacterIds;
    private List<int> Beta_CurrentPartyMemberCharacterIds;
    private List<int> Omega_CurrentPartyMemberCharacterIds;

    //These dictionaries have the character id and the soul paradigm. They encompass all characters, regardless of access.
    public Dictionary<int, Paradigm> allyEquippedSouldParadigms;
    private Dictionary<int, Paradigm> Alpha_AllyEquippedSouldParadigms;
    private Dictionary<int, Paradigm> Beta_AllyEquippedSouldParadigms;
    private Dictionary<int, Paradigm> Omega_AllyEquippedSouldParadigms;
    #endregion

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

    public void InitializeGameData()
    {
        if (MasterControl.Instance.GetCurrentGameDataFile() == GameDataFile.Aplha)
        {
            playerLocation = Alpha_PlayerLocation;
            currentPartyMemberCharacterIds = Alpha_CurrentPartyMemberCharacterIds;
            playerEquippedSoulParadigm = Alpha_PlayerEquippedSoulParadigm;
            aquiredTreeNodes = Alpha_AquiredTreeNodes;
            playerCoreFirewall = Alpha_PlayerCoreFirewall;
            playerCompiler = Alpha_PlayerCompiler;
            playerDefenseMatrix = Alpha_PlayerDefenseMatrix;
            playerPredictiveAlgorithms = Alpha_PlayerPredictiveAlgorithms;

        }
        else if (MasterControl.Instance.GetCurrentGameDataFile() == GameDataFile.Beta)
        {

        }
        else if (MasterControl.Instance.GetCurrentGameDataFile() == GameDataFile.Omega)
        {

        }

        #region Testing
        playerLocation = Location.Hub_Town;
        currentPartyMemberCharacterIds = new List<int>
        {
            2,
            3
        };
        playerEquippedSoulParadigm = Paradigm.Sorceror;
        aquiredTreeNodes = new List<TreeNode>()
        {
            TreeNodeDatabase.Instance.treeNodeDatabase[0],
            TreeNodeDatabase.Instance.treeNodeDatabase[1]

        };

        allyEquippedSouldParadigms = new Dictionary<int, Paradigm>()
        {
            {2, Paradigm.Soldier },
            {3, Paradigm.Bishop }
        };

        playerPatience = 16.5f;
        playerSomething = 16.5f;
        playerCunning = 16.5f;
        playerLogical = 16.5f;
        playerKindness = 16.5f;
        playerCharisma = 16.5f;

        UpdatePlayerStatsAndSkills();
        #endregion
    }

    //Reads save data file and initializes related variables
    private void ReadSaveData()
    {
        if (File.Exists(Application.persistentDataPath + "/Game_Data.sav"))
        {
            FileStream saveFile = File.Open(Application.persistentDataPath + "/Game_Data.sav", FileMode.Open);
            using (saveFile)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                SaveData saveData = (SaveData)binaryFormatter.Deserialize(saveFile);

                //something = saveData.something;
            }
        }
        else
        {
            //First Execution
            //levelZeroGameState = GameStates.First_Execution;
        }

    }

    private void WriteSaveData()
    {
        PrepareGameDataForWrite();

        FileStream saveFile = File.Create(Application.persistentDataPath + "/Game_Data.sav");
        using (saveFile)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            SaveData saveData = new SaveData();
            //saveData.something = something;
            binaryFormatter.Serialize(saveFile, saveData);
        }
    }

    private void PrepareGameDataForWrite ()
    {
        if (MasterControl.Instance.GetCurrentGameDataFile() == GameDataFile.Aplha)
        {
            Alpha_PlayerLocation = playerLocation;
            Alpha_CurrentPartyMemberCharacterIds = currentPartyMemberCharacterIds;
            Alpha_PlayerEquippedSoulParadigm = playerEquippedSoulParadigm;
            Alpha_AquiredTreeNodes = aquiredTreeNodes;
        }
        else if (MasterControl.Instance.GetCurrentGameDataFile() == GameDataFile.Beta)
        {

        }
        else if (MasterControl.Instance.GetCurrentGameDataFile() == GameDataFile.Omega)
        {

        }
    }



    private void UpdatePlayerStatsAndSkills()
    {
        SoulParadigm paradigmInformation = SoulParadigmDatabase.Instance.SoulParadigms.Find(x => x.paradigm == playerEquippedSoulParadigm);

        playerCoreFirewall = paradigmInformation.coreFirewall + SumOfAquiredTreeNodesByType(TreeNodeType.Core_Firewall);
        playerCompiler = paradigmInformation.compiler + SumOfAquiredTreeNodesByType(TreeNodeType.Compiler);
        playerDefenseMatrix = paradigmInformation.defenseMatrix + SumOfAquiredTreeNodesByType(TreeNodeType.Defense_Matrix);
        playerPredictiveAlgorithms = paradigmInformation.predictiveAlgorithms + SumOfAquiredTreeNodesByType(TreeNodeType.Predictive_Algorithms);

        CompilePlayerSkillList();
    }

    //Player Only
    private int SumOfAquiredTreeNodesByType(TreeNodeType nodeType)
    {
        int sum = 0;
        foreach (var node in aquiredTreeNodes)
        {
            if (node.nodeType == nodeType)
            {
                sum += node.nodeValue;
            }
        }

        return sum;
    }

    private void CompilePlayerSkillList()
    {
        playerSkills = new List<Skill>();

        foreach (var skill in SkillDatabase.Instance.skillDatabase)
        {
            //checks equipped paradigm for skills
            if (skill.requiredParadigm == playerEquippedSoulParadigm)
            {
                playerSkills.Add(skill);
            }

            //checks additional paradigm skills
            Paradigm[] additionalParadigmSkills = SoulParadigmDatabase.Instance.SoulParadigms.Find(x => x.paradigm == playerEquippedSoulParadigm).additionalParadigmSkills;
            if (additionalParadigmSkills != null)
            {
                foreach (var additionalParadigm in additionalParadigmSkills)
                {
                    if (skill.requiredParadigm == additionalParadigm)
                    {
                        playerSkills.Add(skill);
                    }
                }
            }
        }
    }
}

[Serializable]
struct SaveData
{
    public List<TreeNode> Alpha_AquiredTreeNodes;
}