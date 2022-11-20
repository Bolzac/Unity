using UnityEngine;
public class Player_Destroy : MonoBehaviour
{
    [SerializeField] GameObject _particle;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile_E"))
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
            //_audioSource.PlayOneShot(_audioSource.clip);
            Destroy(gameObject);
        }
    }
}