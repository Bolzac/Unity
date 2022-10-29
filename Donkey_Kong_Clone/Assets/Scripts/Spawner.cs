using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private float _tmax = 3f;
    private float _tmin = 1f;
    [SerializeField] GameObject Prefab;
    void Start()
    {
        SpawnBarrel();
    }

    private void SpawnBarrel()
    {
        Instantiate(Prefab, transform.position, quaternion.identity);
        Invoke(nameof(SpawnBarrel),Random.Range(_tmin,_tmax));
    }
}
