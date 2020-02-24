using UnityEngine;

[System.Serializable]
public class Abilities
{
    public int abilityId;
    public string abilityName;
    public string abilityDescription;
    public Sprite abilityIcon;
    public int abilityPowerCost;
    public int abilityDamage;
    public int abilityDefense;
    public int abilityRank;
    public int abilityUnlockingClassId;
    public int abilityAnalysisTime;
    public int abilityTurnDuration;
    public int abilityAggro;

    public Abilities(int id, string name, string description, int cost, int damage, int defense, int rank, int classId, int time, int duration, int aggro)
    {
        abilityId = id;
        abilityDescription = description;
        abilityIcon = Resources.Load<Sprite>("Ability Icons/" + name);
        abilityPowerCost = cost;
        abilityDamage = damage;
        abilityDefense = defense;
        abilityRank = rank;
        abilityUnlockingClassId = classId;
        abilityAnalysisTime = time;
        abilityTurnDuration = duration;
        abilityAggro = aggro;
    }
}