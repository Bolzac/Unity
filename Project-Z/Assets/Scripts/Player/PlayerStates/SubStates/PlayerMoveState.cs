using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : GroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string _animBoolName) : base(player, stateMachine, playerData, _animBoolName)
    {
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_horizontalInput == 0)
        {
            Player.StateMachine.ChangeState(Player.PlayerIdleState);
        }else if (Player.PlayerData.isRight && _horizontalInput < 0)
        {
            Player.StateMachine.ChangeState(Player.PlayerFlipState);
            Player.PlayerData.isRight = false;
        }else if (!Player.PlayerData.isRight && _horizontalInput > 0)
        {
            Player.StateMachine.ChangeState(Player.PlayerFlipState);
            Player.PlayerData.isRight = true;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (_horizontalInput > 0)
        {
            Player.transform.localScale = new Vector2(1, 1);
            Player.Rigidbody2D.velocity = Vector2.right * Player.PlayerData.MoveSpeed;
        }else if (_horizontalInput < 0)
        {
            Player.transform.localScale = new Vector2(-1, 1);
            Player.Rigidbody2D.velocity = Vector2.left * Player.PlayerData.MoveSpeed;
        }
    }
}
