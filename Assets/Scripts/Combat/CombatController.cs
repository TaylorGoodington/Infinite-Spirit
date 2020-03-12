using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class CombatController : MonoBehaviour
{
    public static CombatController Instance { get; set; }
    CombatState state;
    CombatScenarioName combatScenario;

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
        CombatSceneController.Instance.ArrangeScene(combatScenario);
        CombatantInformationController.Instance.CombatantInformationInitialization(combatScenario);
        
    }
}