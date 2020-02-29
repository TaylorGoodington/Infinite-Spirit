public class Utility
{
    public enum Location
    {
        Hub_Town = 0,
        Fields = 1
    }

    public enum CombatState
    {
        Initializing = 0,
        Ready = 1,
        Processing = 2,
        Dialogue = 3,
        Cutscene = 4,
        Closing = 5
    }

    //Will be more specific and describe the enemy and number of enemies
    //For example, The first boss will have its own scenario that will inform the model controller what enemies need to be present.
    //Also an encounter in the digital world will have a scenario for each type of enemy and possible variations on number of enemies or compositions with supporting enemies.
    public enum CombatScenarioName
    {
        Worm_Example = 0,
        Boss_Example = 1
    }

    //Events will have their own track as well as locations for combat, combat will be split into regular enemy scenario and boss enemy scenario.
    //public enum TrackScenario
    //{
    //    Exploration = 0,
    //    Normal_Combat = 1,
    //    Boss1_Combat = 2
    //}
}