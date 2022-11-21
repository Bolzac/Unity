using UnityEngine;
public class Enemy_Destroy : MonoBehaviour
{
    [SerializeField] GameObject _particle;
    private Spawner _spawner;
    private GameManager _gameManager;
    private int score;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile_P"))
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _spawner.destroyCount++;
            score = _gameManager.score;
            _gameManager.score = score + 100;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border"))
        {
            Destroy(gameObject);
            _spawner.undestroyCount++;
        }
    }

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (_spawner.destroyCount + _spawner.undestroyCount == _gameManager.EnemyCount)
        {
            _gameManager.EnemyCount = _spawner.undestroyCount;
        }
    }
}