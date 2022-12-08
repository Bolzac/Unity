using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsStandingUp : GroundedState
{
    // Start is called before the first frame update
    public PlayerIsStandingUp(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string _animBoolName) : base(player, stateMachine, playerData, _animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!Player.PlayerData.didHide)
        {
            Player.SpriteRenderer.sprite = Player.PlayerData.player;
            Player.StateMachine.ChangeState(Player.PlayerIdleState);
            Player.InputHandler.HideInput = KeyCode.None;
        }
    }
}
