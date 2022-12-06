using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerState PlayerState;
    public PlayerStateMachine StateMachine;

    public PlayerHideState PlayerHideState;
    public PlayerIdleState PlayerIdleState;
    public PlayerMoveState PlayerMoveState;
    public PlayerFlipState PlayerFlipState;

    public Animator Animator;
    public InputHandler InputHandler;
    public PlayerData PlayerData;
    public Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        PlayerIdleState = new PlayerIdleState(this, StateMachine, PlayerData, "idle");
        PlayerMoveState = new PlayerMoveState(this, StateMachine, PlayerData, "run");
        PlayerHideState = new PlayerHideState(this, StateMachine, PlayerData, "hide");
        PlayerFlipState = new PlayerFlipState(this,StateMachine,PlayerData,"flip");
    }

    private void Start()
    {
        InputHandler = GetComponent<InputHandler>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        StateMachine.Initiliaze(PlayerIdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    
    public void AlertObservers(string message)
    {
        if (message.Equals("FlipAnimationEnded"))
        {
            PlayerData.isAnimationEnded = true;
            // Do other things based on an attack ending.
        }
    }
}
