using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static Utility;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; set; }

    #region Player Data
    public short[] aquiredTreeNodes;
    private short[] Alpha_AquiredTreeNodes;
    private short[] Beta_AquiredTreeNodes;
    private short[] Omega_AquiredTreeNodes;

    public Location playerLocation;
    private Location Alpha_PlayerLocation;
    private Location Beta_PlayerLocation;
    private Location Omega_PlayerLocation;

    public Paradigm playerEquippedSoulParadigm;
    private Paradigm Alpha_PlayerEquippedSoulParadigm;
    private Paradigm Beta_PlayerEquippedSoulParadigm;
    private Paradigm Omega_PlayerEquippedSoulParadigm;
    #endregion

    #region Ally Data
    //ally: potential party members, current party members, (all, unlocked or not) ally personality data, (all, unlocked or not) allies equipped soul paradigm
    public List<short> potentialPartyMemberCharacterIds;
    private List<short> Alpha_PotentialPartyMemberCharacterIds;
    private List<short> Beta_PotentialPartyMemberCharacterIds;
    private List<short> Omega_PotentialPartyMemberCharacterIds;

    public List<short> currentPartyMemberCharacterIds;
    private List<short> Alpha_CurrentPartyMemberCharacterIds;
    private List<short> Beta_CurrentPartyMemberCharacterIds;
    private List<short> Omega_CurrentPartyMemberCharacterIds;

    //These dictionaries have the character id and the soul paradigm. They encompass all characters, regardless of access.
    public Dictionary<short, Paradigm> allyEquippedSouldParadigms;
    private Dictionary<short, Paradigm> Alpha_AllyEquippedSouldParadigms;
    private Dictionary<short, Paradigm> Beta_AllyEquippedSouldParadigms;
    private Dictionary<short, Paradigm> Omega_AllyEquippedSouldParadigms;
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

    private void Start()
    {
        //LoadSaveData();
    }

    public void InititalizeGameData()
    {
        if (MasterControl.Instance.currentFile == GameDataFile.Aplha)
        {
            playerLocation = Alpha_PlayerLocation;
            currentPartyMemberCharacterIds = Alpha_CurrentPartyMemberCharacterIds;
            playerEquippedSoulParadigm = Alpha_PlayerEquippedSoulParadigm;
            aquiredTreeNodes = Alpha_AquiredTreeNodes;
        }
        else if (MasterControl.Instance.currentFile == GameDataFile.Beta)
        {

        }
        else if (MasterControl.Instance.currentFile == GameDataFile.Omega)
        {

        }

        #region Testing
        playerLocation = Location.Hub_Town;
        currentPartyMemberCharacterIds = new List<short>
        {
            2,
            3
        };
        playerEquippedSoulParadigm = Paradigm.Mage;
        aquiredTreeNodes = new short[] {1, 2};

        //initialize current party members and a few of the ally equipped soul dictionaries
        #endregion


    }

    private void LoadSaveData()
    {
        if (File.Exists(Application.persistentDataPath + "/Game_Data.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "/Game_Data.dat", FileMode.Open);
            SaveData saveData = (SaveData)binaryFormatter.Deserialize(saveFile);

            Alpha_AquiredTreeNodes = saveData.Alpha_AquiredTreeNodes;

            saveFile.Close();
        }
        else
        {
            //throw some kind of error message??
        }
    }

    private void SaveData()
    {
        UpdateGameData();

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream saveFile = File.Create(Application.persistentDataPath + "/Game_Data.dat");
        SaveData saveData = new SaveData();

        saveData.Alpha_AquiredTreeNodes = Alpha_AquiredTreeNodes;

        binaryFormatter.Serialize(saveFile, saveData);
        saveFile.Close();
    }

    private void UpdateGameData ()
    {
        if (MasterControl.Instance.currentFile == GameDataFile.Aplha)
        {
            Alpha_PlayerLocation = playerLocation;
            Alpha_CurrentPartyMemberCharacterIds = currentPartyMemberCharacterIds;
            Alpha_PlayerEquippedSoulParadigm = playerEquippedSoulParadigm;
            Alpha_AquiredTreeNodes = aquiredTreeNodes;
        }
        else if (MasterControl.Instance.currentFile == GameDataFile.Beta)
        {

        }
        else if (MasterControl.Instance.currentFile == GameDataFile.Omega)
        {

        }
    }
}

[Serializable]
struct SaveData
{
    public short[] Alpha_AquiredTreeNodes;
    //public short[] Beta_AquiredTreeNodes;
    //public short[] Omega_AquiredTreeNodes;
}