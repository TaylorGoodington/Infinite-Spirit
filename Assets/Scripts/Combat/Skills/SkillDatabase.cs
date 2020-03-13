using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class SkillDatabase : MonoBehaviour
{
    public static SkillDatabase Instance { get; set; }
    public List<Skill> skillDatabase;

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
        skillDatabase = new List<Skill>
        {
            new Skill(0, "Barage 1", "Deals Damage to all enemies on screen.", SkillUnlockType.Paradigm, Paradigm.Wizard, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(1, "Barage 2", "Deals Damage to all enemies on screen.", SkillUnlockType.Paradigm, Paradigm.Mage, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(2, "Barage 3", "Deals Damage to all enemies on screen.", SkillUnlockType.Paradigm, Paradigm.Bard, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(3, "Barage 4", "Deals Damage to all enemies on screen.", SkillUnlockType.Paradigm, Paradigm.Sorceror, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(4, "Battle Cry 1", "Improves ally damage and reduces enemy damage", SkillUnlockType.Paradigm, Paradigm.Paladin, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(5, "Battle Cry 2", "Improves ally damage and reduces enemy damage", SkillUnlockType.Paradigm, Paradigm.Templar, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(6, "Behind Me 1", "Generates a large amount of aggro", SkillUnlockType.Paradigm, Paradigm.Soldier, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(7, "Behind Me 2", "Generates a large amount of aggro", SkillUnlockType.Paradigm, Paradigm.Knight, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(8, "Behind Me 3", "Generates a large amount of aggro", SkillUnlockType.Paradigm, Paradigm.Paladin, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(9, "Behind Me 4", "Generates a large amount of aggro", SkillUnlockType.Paradigm, Paradigm.Templar, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(10, "Blind Spot 1", "High damage move that stuns the enemy.", SkillUnlockType.Paradigm, Paradigm.Archer, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(11, "Blind Spot 2", "High damage move that stuns the enemy.", SkillUnlockType.Paradigm, Paradigm.Ranger, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(12, "Blind Spot 3", "High damage move that stuns the enemy.", SkillUnlockType.Paradigm, Paradigm.Monk, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(13, "Blind Spot 4", "High damage move that stuns the enemy.", SkillUnlockType.Paradigm, Paradigm.Duelist, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(14, "Blinding Speed 1", "Allows two aditional actions to be taken this turn.", SkillUnlockType.Paradigm, Paradigm.Duelist, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(15, "Combo 1", "Mini event that allows multiple strikes depending on performance in event.", SkillUnlockType.Paradigm, Paradigm.Monk, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(16, "Combo 2", "Mini event that allows multiple strikes depending on performance in event.", SkillUnlockType.Paradigm, Paradigm.Duelist, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(17, "Courage 1", "Makes the user immune to loss of control effects.", SkillUnlockType.Paradigm, Paradigm.Soldier, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(18, "Courage 2", "Makes the user immune to loss of control effects.", SkillUnlockType.Paradigm, Paradigm.Knight, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(19, "Courage 3", "Makes the user immune to loss of control effects.", SkillUnlockType.Paradigm, Paradigm.Paladin, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(20, "Courage 4", "Makes the user immune to loss of control effects.", SkillUnlockType.Paradigm, Paradigm.Templar, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(21, "DDOS 1", "Slows the enemys action rate.", SkillUnlockType.Paradigm, Paradigm.Mage, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(22, "DDOS 2", "Slows the enemys action rate.", SkillUnlockType.Paradigm, Paradigm.Bard, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(23, "DDOS 3", "Slows the enemys action rate.", SkillUnlockType.Paradigm, Paradigm.Sorceror, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(24, "Delete 1", "Deals High damage to one enemy.", SkillUnlockType.Paradigm, Paradigm.Wizard, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(25, "Delete 2", "Deals High damage to one enemy.", SkillUnlockType.Paradigm, Paradigm.Mage, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(26, "Delete 3", "Deals High damage to one enemy.", SkillUnlockType.Paradigm, Paradigm.Bard, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(27, "Delete 4", "Deals High damage to one enemy.", SkillUnlockType.Paradigm, Paradigm.Sorceror, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(28, "Expose 1", "Grants allies true damage at the cost of control.", SkillUnlockType.Paradigm, Paradigm.Priest, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(29, "Expose 2", "Grants allies true damage at the cost of control.", SkillUnlockType.Paradigm, Paradigm.Bishop, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(30, "Expose 3", "Grants allies true damage at the cost of control.", SkillUnlockType.Paradigm, Paradigm.Sage, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(31, "Expose 4", "Grants allies true damage at the cost of control.", SkillUnlockType.Paradigm, Paradigm.Shaman, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(32, "Final Strike 1", "Single target strike that is entirely true damage.", SkillUnlockType.Paradigm, Paradigm.Sorceror, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(33, "Fisticuffs 1", "Forces one enemy to trade blows for a few turns. No skills can be used by either party.", SkillUnlockType.Paradigm, Paradigm.Archer, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(34, "Fisticuffs 2", "Forces one enemy to trade blows for a few turns. No skills can be used by either party.", SkillUnlockType.Paradigm, Paradigm.Ranger, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(35, "Fisticuffs 3", "Forces one enemy to trade blows for a few turns. No skills can be used by either party.", SkillUnlockType.Paradigm, Paradigm.Monk, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(36, "Fisticuffs 4", "Forces one enemy to trade blows for a few turns. No skills can be used by either party.", SkillUnlockType.Paradigm, Paradigm.Duelist, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(37, "Flank 1", "Reduces taget enemy defense and does damage.", SkillUnlockType.Paradigm, Paradigm.Bishop, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(38, "Flank 2", "Reduces taget enemy defense and does damage.", SkillUnlockType.Paradigm, Paradigm.Sage, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(39, "Flank 3", "Reduces taget enemy defense and does damage.", SkillUnlockType.Paradigm, Paradigm.Shaman, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(40, "Overclock 1", "Reduces Heat output, reduces casting cost, reduces mana needed, increases speed.", SkillUnlockType.Paradigm, Paradigm.Hero, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(41, "Phalanx 1", "Boosts allies Defense Matrix.", SkillUnlockType.Paradigm, Paradigm.Priest, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(42, "Phalanx 2", "Boosts allies Defense Matrix.", SkillUnlockType.Paradigm, Paradigm.Bishop, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(43, "Phalanx 3", "Boosts allies Defense Matrix.", SkillUnlockType.Paradigm, Paradigm.Sage, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(44, "Phalanx 4", "Boosts allies Defense Matrix.", SkillUnlockType.Paradigm, Paradigm.Shaman, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(45, "Protector 1", "Redirects all damage to user, grants temp hp.", SkillUnlockType.Paradigm, Paradigm.Templar, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(46, "Scramble 1", "Chance to confuse all enemies", SkillUnlockType.Paradigm, Paradigm.Bard, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(47, "Scramble 2", "Chance to confuse all enemies", SkillUnlockType.Paradigm, Paradigm.Sorceror, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(48, "Second Wind 1", "Recovers a portion of the core firewall", SkillUnlockType.Paradigm, Paradigm.Knight, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(49, "Second Wind 2", "Recovers a portion of the core firewall", SkillUnlockType.Paradigm, Paradigm.Paladin, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(50, "Second Wind 3", "Recovers a portion of the core firewall", SkillUnlockType.Paradigm, Paradigm.Templar, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(51, "Sleep 1", "Chance to force the enemy into sleep mode.", SkillUnlockType.Paradigm, Paradigm.Sage, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(52, "Sleep 2", "Chance to force the enemy into sleep mode.", SkillUnlockType.Paradigm, Paradigm.Shaman, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(53, "System Restore 1", "Removes all debuffs and restores health. All Allies", SkillUnlockType.Paradigm, Paradigm.Hero, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(54, "Terminate 1", "Deals massive damage to one enemy.", SkillUnlockType.Paradigm, Paradigm.Hero, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(55, "The best offense 1", "Raises ally defense and allows counterattacks on all actions.", SkillUnlockType.Paradigm, Paradigm.Shaman, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(56, "Upgrade 1", "Improves compiler, defense matrix, and predictive algorthims for all allies.", SkillUnlockType.Paradigm, Paradigm.Hero, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(57, "blank 1", "AOE Regen", SkillUnlockType.Paradigm, Paradigm.Ranger, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(58, "blank 2", "AOE Regen", SkillUnlockType.Paradigm, Paradigm.Monk, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(59, "blank 3", "AOE Regen", SkillUnlockType.Paradigm, Paradigm.Duelist, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0),
            new Skill(60, "TREETEST", "Test tree skill", SkillUnlockType.Tree, Paradigm.Trainee, 5, 1.8f, 0.9f, 0.1f, 1, EnemyTargeting.All, StatusEffect.None, 0, PartyTargeting.None, StatusEffect.None, 0)
        };
    }
}

[System.Serializable]
public class Skill
{
    public int id;
    public string name;
    public string description;
    public SkillUnlockType unlockType;
    public Paradigm requiredParadigm;
    public int powerCost;
    public float attackRating;
    public float defenseRating;
    public float chargeTime;
    public int abilityAggro;
    public EnemyTargeting enemyTargeting;
    public StatusEffect enemyStatusEffect;
    public float enemyStatusEffectDuration;
    public PartyTargeting partyTargeting;
    public StatusEffect partyStatusEffect;
    public float partyStatusEffectDuration;
    public Sprite icon;

    public Skill(int id, string name, string description, SkillUnlockType unlockType, Paradigm requiredParadigm, int powerCost, float chargeTime, float attackRating,
         float defenseRating, int abilityAggro, EnemyTargeting enemyTargeting, StatusEffect enemyStatusEffect, float enemyStatusEffectDuration, PartyTargeting partyTargeting,
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
        //icon = Resources.Load<Sprite>("Skill Icons/" + name);
    }
}