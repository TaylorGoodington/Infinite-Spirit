using System.Collections;
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
        //Initialize Player combat stats + skills
            //class => base stats and skills
            //tree stats => additional stats and skills
            //skill list that is a combination of class skills list (derrived from the database) and aquired tree skills list
                //tree skills database
                //class skills database
    }
}