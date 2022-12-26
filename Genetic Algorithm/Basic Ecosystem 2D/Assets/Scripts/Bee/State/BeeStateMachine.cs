using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStateMachine
{
    public BeeState CurrentState;

    public void Initiliaze(BeeState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(BeeState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}