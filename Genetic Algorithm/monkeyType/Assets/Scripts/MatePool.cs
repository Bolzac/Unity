using System.Collections.Generic;
using Unity.Mathematics;
using Random = System.Random;

public class MatePool
{
    public List<DNA> MatingPool = new List<DNA>();

    private Random _random = new Random();
    public void CreateMatePool(DNA member)
    {
        var count = math.floor(member.Fitness * 100);
        for (int i = 0; i < count; i++)
        {
            MatingPool.Add(member);
        }
    }

    public DNA ChooseParent(DNA parentA)
    {
        int b;
        DNA parentB;
        do {
            b = _random.Next(MatingPool.Count);
            parentB = MatingPool[b];
        } while (parentA.phrase == parentB.phrase);

        return parentB;
    }
}
