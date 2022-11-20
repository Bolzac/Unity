using UnityEngine;
public class Player_Destroy : MonoBehaviour
{
    [SerializeField] GameObject _particle;
    private int _health = 3;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile_E"))
        {
            _health--;
            if (_health == 0)
            {
                Instantiate(_particle, transform.position, Quaternion.identity);
                //_audioSource.PlayOneShot(_audioSource.clip);
                Destroy(gameObject);   
            }
            FindObjectOfType<GameManager>().Health = _health;
        }
    }
}