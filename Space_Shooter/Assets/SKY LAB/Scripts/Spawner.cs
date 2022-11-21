using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float rate = 0.5f;
    [SerializeField] private float rateOfWaves = 1;
    [SerializeField] private GameObject[] enemies;
    private int _count = 0;
    public int destroyCount = 0;
    public int undestroyCount = 0;
    private GameManager _gameManager;
    public void Spawn_Enemy()
    {
        _count++;
        Debug.Log(_count);
        Debug.Log(_gameManager.EnemyCount);
        Instantiate(enemies[_gameManager.Wave-1], enemies[_gameManager.Wave-1].transform.position, quaternion.identity);
        if (_count < _gameManager.EnemyCount)
        {
            Invoke(nameof(Spawn_Enemy),rate);
        }
    }

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        Spawn_Enemy();
    }
    private void Update()
    {
        if (_gameManager.EnemyCount != 0 && destroyCount + undestroyCount == _gameManager.EnemyCount && destroyCount != _gameManager.EnemyCount)
        {
            Debug.Log("spawn");
            _gameManager.EnemyCount = undestroyCount;
            Spawn_Enemy();
        }else if (destroyCount == _gameManager.EnemyCount)
        {
            _count = 0;
            destroyCount = 0;
            undestroyCount = 0;
            _gameManager.EnemyCount = 10;
            _gameManager.NextWave();
            Invoke(nameof(Spawn_Enemy),rateOfWaves);
        }
    }
}