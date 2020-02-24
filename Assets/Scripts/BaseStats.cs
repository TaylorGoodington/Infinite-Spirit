using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public int currentCoreFirewall;
    public int compiler;
    public int defenseMatrix;
    public int defenseMultiplier;
    public int damageMultiplier;

    private int maxCoreFirewall;

    private void Start()
    {
        maxCoreFirewall = 1;
    }

    public void TakeDamage (int damage)
    {
        currentCoreFirewall -= Mathf.Clamp(damage, 0, maxCoreFirewall);
    }
}