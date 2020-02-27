using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilitiy;

public class CombatController : MonoBehaviour
{
    public static CombatController Instance { get; set; }
    CombatState state;
    CombatScenario combatScenario;

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
        CombatSceneController.Instance.ArrangeScene(combatScenario, MasterControl.Instance.playerLocation);
    }
}