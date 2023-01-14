using UnityEngine;

[CreateAssetMenu (fileName = "Enemy Object", menuName = "Enemy")]
public class EnemyObject : BaseObject
{
    public int health;
    public Coin reward;
    public EnemyElements element;
}
