using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public static CombatController Instance { get; set; }
    State state;

    enum State
    {
        Initializing = 0,
        Ready = 1,
        Processing = 2,
        Dialogue = 3,
        Cutscene = 4,
        Closing = 5
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

    public void Initialize()
    {
        Debug.Log("Initializing");
        state = State.Initializing;
        CombatUIController.Instance.TransitionInStart();
        //CombatSceneController.Instance.ArrangeScene();
    }
}