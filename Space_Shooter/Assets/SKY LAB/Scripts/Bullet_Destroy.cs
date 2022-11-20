using UnityEngine;
public class Bullet_Destroy : MonoBehaviour
{
    [SerializeField] float time = 1f;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("Projectile_E"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Projectile_E"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Projectile_P"))
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Invoke(nameof(DestroySelf),time);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
