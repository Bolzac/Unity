using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyModel enemyModel;
    [SerializeField] private PlayerModel playerModel;
    private void Start()
    {
        enemyModel.Results = new RaycastHit2D[10];
    }

    private void Update()
    {
        enemyModel.isTimerStart = enemyModel.isSeenPlayer;
        if (enemyModel.isTimerStart)
        {
            enemyModel.timeCounter += Time.deltaTime;
            if (enemyModel.timeCounter >= enemyModel.maxTimeToFire)
            {
                Attack();
            }
        }
        else
        {
            enemyModel.timeCounter = 0;
        }
    }

    public void GetDamage()
    { 
        enemyModel.health -= 1;
        if(enemyModel.health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }

    private void Attack()
    {
        playerModel.health -= 1;
        enemyModel.timeCounter = 0;
    }
}