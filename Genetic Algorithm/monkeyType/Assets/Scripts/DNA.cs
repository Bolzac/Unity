using System;
using UnityEngine;
using Random = System.Random;

public class DNA
{
    private string _pool = "abcdefghijklmnoprstyzxwABCDEFGHIJKLMNOPRSTYZXW ";
        
    public double Fitness;
    public char[] Genes;
    public string phrase;
    private float _mutationRate;
    private Random _random;
    public DNA(int geneSize,Random random, bool isCreated = true, float mR = 0.01f, float fitness = 0)
    {
        Fitness = fitness;
        _mutationRate = mR;
        _random = random;
        Genes = new char[geneSize];
        if (isCreated)
        {
            for (int i = 0; i < geneSize; i++)
            {
                //Genes[i] = Convert.ToChar(_random.Next(32, 128));
                Genes[i] = _pool[_random.Next(_pool.Length)];
            }
        }
        String();
    }

    public void CalculateFitness(string target)
    {
        float score = 0;
        for (int i = 0; i < target.Length; i++)
        {
            if (Convert.ToChar(target[i]) == Genes[i])
            {
                score++;
            }
        }
        Fitness = Convert.ToDouble(System.String.Format("{0:0.00}", score / target.Length));
    }
    
    public DNA Crossover(DNA otherParent)
    {
        DNA child = new DNA(Genes.Length,_random,isCreated:false);
        for (int i = 0; i < Genes.Length; i++)
        {
            if (_random.NextDouble() > 0.5f)
            {
                child.Genes[i] = Genes[i];
            }else
            {
                child.Genes[i] = otherParent.Genes[i];
            }
        }
        child.String();
        return child;
    }

    public void Mutate()
    {
        for (int i = 0; i < Genes.Length; i++)
        {
            if (_mutationRate > _random.NextDouble())
            {
                //Genes[i] = Convert.ToChar(_random.Next(32, 128));
                Genes[i] = _pool[_random.Next(_pool.Length)];
            }
        }
        String();
    }

    public void String()
    {
        phrase = new string(Genes);
    }
}
