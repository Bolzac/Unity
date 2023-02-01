using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyModel enemyModel;
    private void Start()
    {
        enemyModel.Results = new RaycastHit2D[10];
    }

    public void KilledByGun()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }
}