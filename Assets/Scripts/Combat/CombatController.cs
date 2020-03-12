using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatController : MonoBehaviour
{
    public static CombatController Instance { get; set; }
    CombatState state;
    CombatScenarioName combatScenario;
    public Combatant[] combatants;

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
        #region Testing

        combatScenario = CombatScenarioName.Worm_Example;

        #endregion
    }

    private void Update()
    {
        if (state == CombatState.Initializing)
        {
            //Nada
        }
    }

    public void Initialize()
    {
        Debug.Log("Initializing");
        state = CombatState.Initializing;
        CombatUIController.Instance.TransitionInStart();
        Dictionary<int, short> combatantModelInfo = CombatSceneController.Instance.ArrangeScene(combatScenario);
        BuildCombatantArray(combatantModelInfo);
        CombatantInformationController.Instance.CombatantInformationInitialization(combatScenario);
        
    }

    private void BuildCombatantArray(Dictionary<int, short> combatantModelInfo)
    {
        //combatants = new Combatant[];
        //takes the combatantModels dictionary and creates the combtants array
            //need to finish the CombatSceneController ArrangeScene method....
    }
}

[Serializable]
public class Combatant
{
    public int objectInstanceId;
    public short characterId;
    public CombatantType combatantType;
}