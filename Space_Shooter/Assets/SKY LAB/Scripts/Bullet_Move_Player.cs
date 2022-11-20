using UnityEngine;
public class Bullet_Move_Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float _speed = 10f;
    private Vector2 _direction;
    private Vector2 _currentPosition;
    private void SetSpeed()
    {
        _direction = Vector2.up * _speed;
    }
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetSpeed();
    }
    private void FixedUpdate()
    {
        _currentPosition = transform.position;
        rigidbody2D.MovePosition(_currentPosition + _direction * Time.fixedDeltaTime);
    }
}