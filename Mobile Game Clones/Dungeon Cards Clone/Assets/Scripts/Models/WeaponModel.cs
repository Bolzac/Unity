using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : VitalModel
{
    public WeaponObject weaponData;

    private void Start()
    {
        currentHealth = weaponData.health;
    }
}

public enum WeaponElements
{
    Ice,
    Fire,
    Poison,
    None
}

public enum WeaponTypes
{
    Melee,
    Ranged,
    Line
}