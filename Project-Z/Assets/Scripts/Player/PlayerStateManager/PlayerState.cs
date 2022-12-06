using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public Player Player;
    public PlayerStateMachine StateMachine;
    public PlayerData PlayerData;

    private string _animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string _animBoolName)
    {
        this.Player = player;
        this._animBoolName = _animBoolName;
        this.PlayerData = playerData;
        this.StateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        Player.Animator.SetBool(_animBoolName,true);
    }
    public virtual void Exit()
    {
        Player.Animator.SetBool(_animBoolName,false);
    }
    public virtual void LogicUpdate()
    {
        
    }
    public virtual void PhysicsUpdate()
    {
        
    }
}
