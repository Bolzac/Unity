using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipState : GroundedState
{
    public PlayerFlipState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string _animBoolName) : base(player, stateMachine, playerData, _animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Player.PlayerData.isAnimationEnded)
        {
            if (Player.PlayerData.isRight)
            {
                if (_horizontalInput > 0)
                {
                    Player.StateMachine.ChangeState(Player.PlayerMoveState);   
                }else if (_horizontalInput == 0)
                {
                    Player.StateMachine.ChangeState(Player.PlayerIdleState);
                }
            }else if (!Player.PlayerData.isRight)
            {
                if (_horizontalInput < 0)
                {
                    Player.StateMachine.ChangeState(Player.PlayerMoveState);
                }else if (_horizontalInput == 0)
                {
                    Player.StateMachine.ChangeState(Player.PlayerIdleState);
                }
            }

            Player.PlayerData.isAnimationEnded = false;
        }
    }
}
