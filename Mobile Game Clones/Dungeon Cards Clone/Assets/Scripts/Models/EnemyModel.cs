public class EnemyModel : VitalModel
{
    public EnemyObject enemyData;

    public bool killedByWeapon;
    
    private void Start()
    {
        currentHealth = enemyData.health;
    }
}

public enum EnemyElements
{
    Fire,
    Ice,
    None
}