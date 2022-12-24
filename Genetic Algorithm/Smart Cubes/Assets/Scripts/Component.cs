using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Component : MonoBehaviour
{
    [SerializeField] private GameObject rocket;
    public List<Rocket> population = new List<Rocket>();
    public List<Rocket> matePool = new List<Rocket>();
    private int _populationSize;

    private int _generation;

    private double _distanceToTarget;
    
    [SerializeField] private Collider2D target;

    private DNA[] _children;
    
    //Time Counter
    private float _frameCount;
    //UI
    [SerializeField] private Text countField;

    [SerializeField] private Text generationField;
    //Random
    private System.Random _random;

    private void Awake()
    {
        _random = new System.Random();
        _populationSize = 500;
    }

    void Start()
    {
        _children = new DNA[_populationSize];
        _frameCount = 300;
        _distanceToTarget = Math.Sqrt(Math.Pow((double)target.transform.position.y - transform.position.y, 2) + Math.Pow((double)target.transform.position.x - transform.position.x, 2));
        _distanceToTarget = Convert.ToDouble($"{_distanceToTarget:0.00}");
        _generation = 1;
        CreatePopulation();
    }
    
    void Update()
    {
        countField.text = $"Time: {_frameCount.ToString()}";
        generationField.text = $"Generation: {_generation.ToString()}";
        if (_frameCount > 0)
        {
            _frameCount--;
        }
        else
        {
            Selection();
            Reproduction();
            DestroyAllRockets();
            CreateNextPopulation();
            _generation++;
            _frameCount = 300;
        }
    }

    public void CreatePopulation()
    {
        for (int i = 0; i < _populationSize; i++)
        {
            Instantiate(rocket, transform.position, Quaternion.identity);
        }

        population = FindObjectsOfType<Rocket>().ToList();
        foreach (var item in population)
        {
            item.StartWithoutDna(_random);
        }
    }

    public void CreateNextPopulation()
    {
        for (int i = 0; i < _populationSize; i++)
        {
            population[i].StartWithDna(_children[i]);
            population[i].gameObject.SetActive(true);
        }
    }

    public void Selection()
    {
        //Calculate Fitness +
        //Create Mate Pool +
        foreach (var item in population)
        {
            item.CalculateFitness(target,(float)_distanceToTarget);
            var count = item.Fitness * 100;
            Debug.Log(count);
            for (int i = 0; i < count; i++)
            {
                matePool.Add(item);
            }
            Debug.Log(matePool.Count);
        }
    }

    public void Reproduction()
    {
        DNA child;
        int a = _random.Next(matePool.Count);
        DNA parentA = matePool[a].Dna;
        int b = _random.Next(matePool.Count);
        DNA parentB = matePool[b].Dna;
        for (int i = 0; i < _populationSize; i++)
        {
            child = parentA.Crossover(parentB, _random);
            child.Mutate(_random);
            _children[i] = child;
        }
    }

    public void DestroyAllRockets()
    {
        foreach (var item in population)
        {
            item.ResetPosition();
            item.gameObject.SetActive(false);
        }
    }
}