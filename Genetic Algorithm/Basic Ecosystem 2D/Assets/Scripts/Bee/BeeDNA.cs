using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BeeDNA
{
    public float[] Genes; //Speed, sex, sense

    public BeeDNA(Random random, bool isCreated = false)
    {
        if (isCreated)
        {
            Genes[0] = random.Next(1, 5);
            Genes[1] = random.Next(1);
            Genes[2] = random.Next(1, 5);
        }
    }
    
    public BeeDNA Crossover(BeeDNA maleBee)
    {
        //After crossover female bee going to create child
        return maleBee;
    }
}
