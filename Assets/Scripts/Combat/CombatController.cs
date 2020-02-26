using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public static CombatController Instance { get; set; }
    CombatState state;
    CombatScenario scenario;

    public enum CombatState
    {
        Initializing = 0,
        Ready = 1,
        Processing = 2,
        Dialogue = 3,
        Cutscene = 4,
        Closing = 5
    }

    public enum CombatScenario
    {
        Normal = 0,
        Boss = 1
    }

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

        }
    }

    public void Initialize()
    {
        Debug.Log("Initializing");
        state = CombatState.Initializing;
        CombatUIController.Instance.TransitionInStart();
        MusicManager.Instance.StartCombatMusic(scenario, MasterControl.Instance.playerLocation);

        //CombatSceneController.Instance.ArrangeScene();
    }
}