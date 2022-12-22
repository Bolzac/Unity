using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private Population _population;
    private MatePool _matePool;

    public int generation;
    public float maxFitness;
    public string targetPhrase;

    private System.Random _random;

    [SerializeField] private Text GenerationValue;
    [SerializeField] private Text GuessPhrase;
    [SerializeField] private Text FitnessValue;

    private void Awake()
    {
        _random = new System.Random();
        _population = new Population();
        _matePool = new MatePool();
    }

    void Start()
    {
        targetPhrase = "to be or not to be";
        generation = 1;
        _population.CreatePopulation(targetPhrase);
    }

    // Update to next generation
    void Update()
    {
        if (_population.fittestMember != null && targetPhrase == _population.fittestMember.phrase)
        {
            return;
        }
        Selection();
        _population.FindFittestMemberInPopulation();
        Debug.Log(_population.fittestMember.phrase);
        SetUI();
        Reproduction();
        NextGen();
    }

    private void Selection()
    {
        foreach (var member in _population.population)
        {
            member.CalculateFitness(targetPhrase);
            _matePool.CreateMatePool(member);
        }
    }

    
    private void Reproduction()
    {
        for (int i = 0; i < _population.population.Length; i++)
        {
            DNA child = new DNA(_population.population[i].phrase.Length, _random, isCreated: false);
            var a = _random.Next(_matePool.MatingPool.Count);
            DNA parentA = _matePool.MatingPool[a];
            DNA parentB = _matePool.ChooseParent(parentA);
            child = parentA.Crossover(parentB);
            child.Mutate();
            _population.population[i] = child;
            //_population.nextGenPopulation[i] = child;
        }
    }

    private void NextGen()
    {
        //_population.SetNewPopulation();
        generation++;
    }
    
    private void SetUI()
    {
        GenerationValue.text = generation.ToString();
        GuessPhrase.text = _population.fittestMember.phrase;
        FitnessValue.text = _population.fittestMember.Fitness.ToString();
    }
}
