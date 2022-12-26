using System;
using UnityEngine;
using Random = System.Random;

public class Bee : MonoBehaviour
{
    public BeeState BeeState;
    public BeeStateMachine StateMachine;
    public BeeDNA Dna;

    private float _moveSpeed;
    private bool _isMale;
    private float _speedOnFlower;
    private float _senseArea;

    private void Awake()
    {
        StateMachine = new BeeStateMachine();
        BeeState = new BeeState(this,StateMachine);
    }

    void Start()
    {
        StateMachine.CurrentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        //Bee's hunger going to grow until max value
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void ConstructWithoutDna(Random random)
    {
        //Assign first population member's dna
        Dna = new BeeDNA(random);
    }

    public void CreateChild()
    {
        //To create it's child if it is female
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //is flower in Sense area
        throw new NotImplementedException();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //is flower in Sense area
        throw new NotImplementedException();
    }
}
