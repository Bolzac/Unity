using System;
using UnityEngine;
using Random = System.Random;

public class Rocket : MonoBehaviour
{
    public Vector2 MoveDirection;
    public DNA Dna;
    private float _timeRemain;
    private int _orderCount;
    private Vector2 _beginPosition;

    public float Fitness;

    private Collider2D _collider2D;

    public void StartWithoutDna(Random random)
    {
        Dna = new DNA(random);
    }

    public void StartWithDna( DNA dna)
    {
        Dna = dna;
    }
    
    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        Fitness = 0;
        _orderCount = 0;
        _beginPosition = transform.position;
        _timeRemain = Dna.Genes[_orderCount].LifeSpan;
        MoveDirection = Dna.Genes[_orderCount].Vector2;
    }

    private void Update()
    {
        if (_timeRemain > 0)
        {
            _timeRemain--;
            transform.position += (Vector3)MoveDirection * Time.deltaTime;
        }
        else
        {
            if (Dna.Genes.Length > _orderCount)
            {
                _orderCount++;
                _timeRemain = 5;
                MoveDirection = Dna.Genes[_orderCount].Vector2;
            }
        }
    }

    public void CalculateFitness(Collider2D target,float maxDistance)
    {
        var distance = Physics2D.Distance(_collider2D, target).distance;
        if (distance > maxDistance)
        {
            Fitness =(float)Convert.ToDouble($"{ 1/ distance:0.00}");
        }else if (distance == maxDistance)
        {
            Fitness = 1 / 9;
        }
        else
        {
            Fitness = (float)Convert.ToDouble($"{(maxDistance - distance) / maxDistance:0.00}");
        }
    }

    public void ResetPosition()
    {
        transform.position = _beginPosition;
        _orderCount = 0; 
    }
}