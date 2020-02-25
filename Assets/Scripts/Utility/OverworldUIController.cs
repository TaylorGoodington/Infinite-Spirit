using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldUIController : MonoBehaviour
{
    public static OverworldUIController Instance { get; set; }
    private Animator animator;

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
        animator = GetComponent<Animator>();
    }

    public void TransitionOut()
    {
        animator.Play("TransitionOut");
    }
}
