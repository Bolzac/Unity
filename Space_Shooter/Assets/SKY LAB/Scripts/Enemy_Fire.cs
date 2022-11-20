using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy_Fire : MonoBehaviour
{
    [SerializeField] private float _min = 1f;
    [SerializeField] private float _max = 5f;
    private float _t;
    [SerializeField] private GameObject bullet;
    private AudioSource gun;

    private void Awake()
    {
        gun = gameObject.GetComponent<AudioSource>();
    }

    private void Attack()
    {
        gun.PlayOneShot(gun.clip);
        Instantiate(bullet, transform.position, quaternion.identity);
        _t = Random.Range(_min, _max);
        Invoke(nameof(Attack),_t);
    }
    private void Start()
    {
        Attack();
    }
};
