using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Player
{
    private void Awake()
    {
        Rb2 = GetComponent<Rigidbody2D>();
        Movespeed = Movespeed * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        CurrentPosition = transform.position;
        Rb2.MovePosition(CurrentPosition + Direction*Movespeed);
    }
}
