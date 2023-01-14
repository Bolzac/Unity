using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinModel : VitalModel
{
    public CoinType type;
    public int powerUp;
}

public enum CoinType
{
    Coin,
    Emerald,
    Mine
}