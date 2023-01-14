using System;
using UnityEngine;

public class PotionModel : VitalModel
{
    public PotionObject potionData;
    
    private void Start()
    {
        currentHealth = potionData.health;
    }
}

public enum PotionTypes
{
    Red,
    Blue,
    Poison
}