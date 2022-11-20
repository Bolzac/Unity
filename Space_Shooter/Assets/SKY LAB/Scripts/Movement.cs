using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Movement : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rb2;
    private Vector2 _currentPosition;
    private Vector2 _positionChange;
    [SerializeField] float speed = 8f;

    private void Awake()
    {
        _rb2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        _currentPosition = transform.position;
        _positionChange = _direction * speed;
        _rb2.MovePosition(_currentPosition + _positionChange * Time.fixedDeltaTime);
    }
}
