using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeState
{
    public Bee Player;
    public BeeStateMachine StateMachine;

    public BeeState(Bee bee, BeeStateMachine stateMachine)
    {
        this.Player = bee;
        this.StateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        
    }
    public virtual void Exit()
    {
    }
    public virtual void LogicUpdate()
    {
        
    }
    public virtual void PhysicsUpdate()
    {
        
    }
}
