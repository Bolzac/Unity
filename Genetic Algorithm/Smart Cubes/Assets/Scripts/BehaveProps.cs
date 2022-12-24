using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BehaveProps
{
    public Vector2 Vector2;
    public float LifeSpan;

    public BehaveProps(Vector2 vector2, float lifeSpan)
    {
        Vector2 = vector2;
        LifeSpan = lifeSpan;
    }
}