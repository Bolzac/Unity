using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHideIdleState : GroundedState

{
    public PlayerHideIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string _animBoolName) : base(player, stateMachine, playerData, _animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        Player.Rigidbody2D.velocity = Vector2.zero;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_horizontalInput != 0)
        {
            Player.StateMachine.ChangeState(Player.PlayerHideWalkState);
        }
        if (Hide == KeyCode.F && Player.PlayerData.didHide)
        {
            Player.StateMachine.ChangeState(Player.PlayerIsStandingUp);
        }
    }
}
