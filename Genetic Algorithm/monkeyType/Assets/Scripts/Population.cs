using System;

public class Population
{
    public DNA[] population = new DNA[500];
    public DNA fittestMember;
    private Random _random = new Random();
    public void CreatePopulation(string target)
    {
        for (var i = 0; i < population.Length; i++)
        {
            population[i] = new DNA(target.Length,_random);
            //population[i].String();
        }
    }

    public void FindFittestMemberInPopulation()
    {
        var fittest = population[0];
        for (var i = 1; i < population.Length; i++)
        {
            if (fittest.Fitness < population[i].Fitness)
            {
                fittest = population[i];
            }
        }

        fittestMember = fittest;
    }
}
