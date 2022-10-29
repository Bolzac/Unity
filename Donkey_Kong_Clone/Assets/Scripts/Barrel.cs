using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D _rb2;
    private bool _grounded;
    private bool _direction = true;
    private Collider2D[] _results;
    private Collider2D _collider2D;
    [SerializeField] private float moveSpeed = 1f;

    private void CollisionDetection()
    {
        _grounded = false;
        Vector2 size = _collider2D.bounds.size;
        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, _results);
        for (int i = 0; i < amount; i++)
        {
            GameObject hit = _results[i].gameObject;
            if (hit.layer == LayerMask.NameToLayer("Ground"))
            {
                _grounded = true;
            }

            if (hit.layer == LayerMask.NameToLayer("Left"))
            {
                _direction = true;
            }

            if (hit.layer == LayerMask.NameToLayer("Right"))
            {
                _direction = false;
            }
        }
    }

    private void Awake()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _results = new Collider2D[4];
    }
    private void Update()
    {
        CollisionDetection();

        if (_grounded)
        {
            if (_direction)
            {
                _rb2.velocity = Vector2.right * moveSpeed;    
            }
            else
            {
                _rb2.velocity = Vector2.left * moveSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
