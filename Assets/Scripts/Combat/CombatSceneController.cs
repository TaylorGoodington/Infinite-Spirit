using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSceneController : MonoBehaviour
{
    public static CombatSceneController Instance { get; set; }

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
            DontDestroyOnLoad(this.gameObject);
        }
    }

    //TODO - Write
    public void ArrangeScene()
    {

    }
}
