using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyModel enemyModel;
    private void Update()
    {
        CreateVision();
    }

    private void CreateVision()
    {
        enemyModel.catchCounter = (int)(enemyModel.maxAngle/enemyModel.perAngle + 1);
        for (float i = (-1) * (enemyModel.maxAngle/enemyModel.perAngle/2); i <= enemyModel.maxAngle/enemyModel.perAngle/2 ; i++)
        {
            Physics2D.LinecastNonAlloc(enemyModel.eye.position, new Vector2(
                    enemyModel.eye.position.x + Mathf.Cos(enemyModel.perAngle * i * Mathf.Deg2Rad) * enemyModel.radius,
                    enemyModel.eye.position.y + Mathf.Sin(enemyModel.perAngle * i * Mathf.Deg2Rad) * enemyModel.radius),
                enemyModel.Results,
                LayerMask.GetMask("World"));

            if (!enemyModel.Results[1].transform.CompareTag("Player")) enemyModel.catchCounter--;
            
            Test(i);
        }

        if (enemyModel.catchCounter == 0 && enemyModel.isSeenPlayer)
        {
            enemyModel.isSeenPlayer = false;
            enemyModel.onCatch.Invoke(enemyModel.isSeenPlayer);
        } 
        else if (enemyModel.catchCounter != 0 && !enemyModel.isSeenPlayer)
        {
            enemyModel.isSeenPlayer = true;
            enemyModel.onCatch.Invoke(enemyModel.isSeenPlayer);
        }
    }

    private void Test(float i)
    {
        Debug.DrawLine(enemyModel.eye.position, new Vector2(
                enemyModel.eye.position.x + Mathf.Cos(enemyModel.perAngle * i * Mathf.Deg2Rad) * enemyModel.radius,
                enemyModel.eye.position.y + Mathf.Sin(enemyModel.perAngle * i * Mathf.Deg2Rad) * enemyModel.radius),
            enemyModel.isSeenPlayer ? Color.red : Color.white);
    }
}