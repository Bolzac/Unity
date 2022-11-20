using Unity.Mathematics;
using UnityEngine;
public class Player_Fire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float _canAttack;
    private float _attackDelay = 0.2f;
    private AudioSource gun;

    private void Awake()
    {
        gun = gameObject.GetComponent<AudioSource>();
    }

    private void Attack()
    {
        gun.PlayOneShot(gun.clip);
        Instantiate(bullet,transform.position,quaternion.identity);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canAttack)
        {
            Attack();
            _canAttack = Time.time + _attackDelay;
        }
    }
}
