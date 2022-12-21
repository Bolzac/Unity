using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerState PlayerState;
    public PlayerStateMachine StateMachine;
    
    public PlayerIdleState PlayerIdleState;
    public PlayerMoveState PlayerMoveState;
    public PlayerFlipState PlayerFlipState;
    public PlayerHideIdleState PlayerHideIdleState;
    public PlayerHideWalkState PlayerHideWalkState;
    public PlayerIsHidingState PlayerIsHidingState;
    public PlayerIsStandingUp PlayerIsStandingUp;

    public Animator Animator;
    public InputHandler InputHandler;
    public PlayerData PlayerData;
    public Rigidbody2D Rigidbody2D;
    public SpriteRenderer SpriteRenderer;

    private RaycastHit2D[] raycastHit2Ds;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        PlayerIdleState = new PlayerIdleState(this, StateMachine, PlayerData, "idle");
        PlayerMoveState = new PlayerMoveState(this, StateMachine, PlayerData, "run");
        PlayerFlipState = new PlayerFlipState(this,StateMachine,PlayerData,"flip");
        PlayerHideIdleState = new PlayerHideIdleState(this, StateMachine, PlayerData, "hideIdle");
        PlayerHideWalkState = new PlayerHideWalkState(this, StateMachine, PlayerData, "hideWalk");
        PlayerIsHidingState = new PlayerIsHidingState(this, StateMachine, PlayerData, "hide");
        PlayerIsStandingUp = new PlayerIsStandingUp(this, StateMachine, PlayerData, "standUp");
    }

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        InputHandler = GetComponent<InputHandler>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        PlayerData.isRight = true;
        PlayerData.didHide = false;
        PlayerData.isAnimationEnded = false;
        raycastHit2Ds = new RaycastHit2D[5];
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
        }else if (message.Equals("HideStatusTrue"))
        {
            PlayerData.didHide = true;
            PlayerData.player = SpriteRenderer.sprite;
        }else if (message.Equals("HideStatusFalse"))
        {
            PlayerData.didHide = false;
            PlayerData.player = SpriteRenderer.sprite;
        }else if (message.Equals("CreateStepSound"))
        {
            var count = Physics2D.RaycastNonAlloc(transform.Find("A").position, transform.Find("B").position,
                raycastHit2Ds);
            Debug.DrawRay(transform.Find("A").position,transform.Find("B").position,Color.white);
            for (var i = 0; i < count; i++)
            {
                if (raycastHit2Ds[i].collider.CompareTag("Enemy"))
                {
                    Debug.Log("Düşman tespiti");
                }
            }
        }
    }
}
