using System;

public interface IDNA
{
    public double Fitness { get; set; }
    public int[] Genes{ get; set; }
    public float MutationRate{ get; set; }
    public Random Random{ get; set; }
    public void CalculateFitness(string target);
    public DNA Crossover(DNA otherParent);
    public void Mutate();
}
