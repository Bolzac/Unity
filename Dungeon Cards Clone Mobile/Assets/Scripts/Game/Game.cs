using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class Game : MonoBehaviour
{
    [SerializeField] public GameObject[] Entities;
    [SerializeField] public GameObject Player;
    [SerializeField] public Transform[] Positions;

    private Random _random;

    private void Awake()
    {
        _random = new Random();
    }

    private void Start()
    {
        InitializeEntities();
    }

    private void InitializeEntities()
    {
        Instantiate(Player,Positions[4].position,quaternion.identity);
        foreach (var transform1 in Positions)
        {
            if (transform1.position != Vector3.zero)
            {
                Instantiate(Entities[_random.Next(0, Entities.Length)], transform1.position, quaternion.identity);
            }
        }
    }

    public void CreateNewEntity()
    {
        
    }
}
