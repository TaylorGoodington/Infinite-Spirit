using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static Utility;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; set; }

    public short[] aquiredTreeNodes;
    private short[] Alpha_AquiredTreeNodes;
    private short[] Beta_AquiredTreeNodes;
    private short[] Omega_AquiredTreeNodes;

    public Location playerLocation;
    private Location Alpha_PlayerLocation;
    private Location Beta_PlayerLocation;
    private Location Omega_PlayerLocation;

    public List<short> allyIds;
    private List<short> Alpha_AllyIds;
    private List<short> Beta_AllyIds;
    private List<short> Omega_AllyIds;


    public short playerEquippedSoulParadigmId;
    private short Alpha_PlayerEquippedSoulId;
    private short Beta_PlayerEquippedSoulId;
    private short Omega_PlayerEquippedSoulId;

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
            allyIds = Alpha_AllyIds;
            playerEquippedSoulParadigmId = Alpha_PlayerEquippedSoulId;
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
        allyIds = new List<short>
        {
            2,
            3
        };
        playerEquippedSoulParadigmId = 6;
        aquiredTreeNodes = new short[] {1, 2};
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
            Alpha_AllyIds = allyIds;
            Alpha_PlayerEquippedSoulId = playerEquippedSoulParadigmId;
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
    public short[] Beta_AquiredTreeNodes;
    public short[] Omega_AquiredTreeNodes;
}