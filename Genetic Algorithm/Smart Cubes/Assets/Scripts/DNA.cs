using UnityEngine;
using Random = System.Random;

public class DNA
{
    public BehaveProps[] Genes { get; set; }
    public float MutationRate { get; set; }
    public DNA(Random random,int geneSize = 60,float mutationRate = 0.01f , bool isCreated = true)
    {
        Genes = new BehaveProps[geneSize];
        MutationRate = mutationRate;
        if (isCreated)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = new BehaveProps(new Vector2(random.Next(-10, 10),random.Next(-10, 10)),5);
            }   
        }
    }

    public DNA Crossover(DNA otherParent, Random random)
    {
        DNA child = new DNA(random,isCreated:false);
        for (int i = 0; i < Genes.Length; i++)
        {
            if (random.NextDouble() > 0.5f)
            {
                child.Genes[i] = Genes[i];
            }
            else
            {
                child.Genes[i] = otherParent.Genes[i];
            }
        }

        return child;
    }

    public void Mutate(Random random)
    {
        for (int i = 0; i < Genes.Length; i++)
        {
            if (random.NextDouble() < MutationRate)
            {
                Genes[i] = new BehaveProps(new Vector2(random.Next(-5, 5),random.Next(-5, 5)),random.Next(1, 3));
            }
        }
    }
}
