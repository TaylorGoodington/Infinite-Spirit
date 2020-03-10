using UnityEngine;
using System.Collections.Generic;
using static Utility;

public class SkillDatabase : MonoBehaviour
{
    public static SkillDatabase Instance { get; set; }
    private List<Skill> SoulParadigms;

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
        SoulParadigms = new List<Skill>();
    }
}

[System.Serializable]
public class Skill
{
    public byte id;
    public string name;
    public string description;
    public SkillUnlockType unlockType;
    public Paradigm requiredParadigm;
    public byte powerCost;
    public float attackRating;
    public float defenseRating;
    public float chargeTime;
    public byte abilityAggro;
    public EnemyTargeting enemyTargeting;
    public StatusEffect enemyStatusEffect;
    public float enemyStatusEffectDuration;
    public PartyTargeting partyTargeting;
    public StatusEffect partyStatusEffect;
    public float partyStatusEffectDuration;
    public Sprite icon;

    public Skill(byte id, string name, string description, SkillUnlockType unlockType, Paradigm requiredParadigm, byte powerCost, float chargeTime, float attackRating,
         float defenseRating, byte abilityAggro, EnemyTargeting enemyTargeting, StatusEffect enemyStatusEffect, float enemyStatusEffectDuration, PartyTargeting partyTargeting,
        StatusEffect partyStatusEffect, float partyStatusEffectDuration)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.unlockType = unlockType;
        this.requiredParadigm = requiredParadigm;
        this.powerCost = powerCost;
        this.chargeTime = chargeTime;
        this.attackRating = attackRating;
        this.defenseRating = defenseRating;
        this.abilityAggro = abilityAggro;
        this.enemyTargeting = enemyTargeting;
        this.enemyStatusEffect = enemyStatusEffect;
        this.enemyStatusEffectDuration = enemyStatusEffectDuration;
        this.partyTargeting = partyTargeting;
        this.partyStatusEffect = partyStatusEffect;
        this.partyStatusEffectDuration = partyStatusEffectDuration;
        icon = Resources.Load<Sprite>("Skill Icons/" + name);
    }
}