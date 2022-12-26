using System;
using UnityEngine;
using Random = System.Random;

public class Gold : MonoBehaviour
{
    public Stats GoldStats;
    public Random ObjectRandom;
    public int PowerUpTurnPower;

    private void Awake()
    {
        ObjectRandom = new Random();
        GoldStats = new Stats(ObjectRandom.Next(1,9));
    }

    private void Update()
    {
        CheckValue();
    }

    private void CheckValue()
    {
        PowerUpTurnPower = GoldStats.Health >= 10 ? 3 : 1;
    }

    private int ReduceTurnForPowerUp(int PowerUpTurns)
    {
        return PowerUpTurns - PowerUpTurnPower;
    }
}
