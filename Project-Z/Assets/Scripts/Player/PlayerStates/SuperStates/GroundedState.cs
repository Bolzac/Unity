using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    protected float _horizontalInput;
    protected KeyCode Hide;
    public GroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string _animBoolName) : base(player, stateMachine, playerData, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _horizontalInput = Player.InputHandler.GetHorizontalInput();
        Hide = Player.InputHandler.GetHideInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
