public class Stats
{
    public int Health;
    public Stats(int health, bool isPlayer = false)
    {
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage >= Health)
        {
            Health = 0;   
        }
        else
        {
            Health -= damage;
        }
    }
}