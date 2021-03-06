﻿public class Utility
{
    public static short PLAYER_CHARACTER_ID = 6;
    public static float PERSONALITY_BONUS_THRESHOLD = .7f;

    public enum Location
    {
        Hub_Town,
        Fields,
        Test_1
    }

    public enum CombatState
    {
        Initializing,
        Ready,
        Processing,
        Dialogue,
        Cutscene,
        Closing
    }

    //Will be more specific and describe the enemy and number of enemies
    //For example, The first boss will have its own scenario that will inform the model controller what enemies need to be present.
    //Also an encounter in the digital world will have a scenario for each type of enemy and possible variations on number of enemies or compositions with supporting enemies.
    public enum CombatScenarioName
    {
        Worm_Example,
        Worm_Example_2,
        Boss_Example
    }

    public enum CombatSetName
    {
        Example_1,
        Example_2
    }

    public enum GameDataFile
    {
        Aplha,
        Beta,
        Omega
    }

    public enum Paradigm
    {
        Trainee,
        Soldier,
        Knight,
        Paladin,
        Templar,
        Priest,
        Bishop,
        Sage,
        Shaman,
        Wizard,
        Mage,
        Bard,
        Sorceror,
        Archer,
        Ranger,
        Monk,
        Duelist,
        Hero
    }

    public enum StatusEffect
    {
        None,
        Haste,
        Slow
    }

    public enum EnemyTargeting
    {
        None,
        Single,
        All
    }

    public enum PartyTargeting
    {
        None,
        Self,
        All
    }

    public enum SkillUnlockType
    {
        Paradigm,
        Tree
    }

    public enum CombatantType
    {
        Player,
        Ally,
        Enemy
    }

    public enum TreeNodeType
    {
        Core_Firewall,
        Compiler,
        Defense_Matrix,
        Predictive_Algorithms,
        Skill
    }

    public enum PersonalityCategory
    {
        Patience,
        Something,
        Cunning,
        Logical,
        Kindness,
        Charisma
    }

    public enum InputStates
    {
        Null,
        None,
        Overworld,
        Menus,
        Dialogue
    }

    public enum ButtonPresses
    {
        None,
        Interact,
        Jump,
        Cast,
        Select,
        Advance
    }

    public enum SoundEffects
    {
        Null,
        Company_Logo,
        Player_Death
    }

    public enum MusicTracks
    {
        Null,
        Level_Zero_Normal,
        Level_One_Normal,
        Player_Death
    }
}