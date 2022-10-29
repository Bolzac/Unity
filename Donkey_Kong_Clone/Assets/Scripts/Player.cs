using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb2;
    private Vector2 _direction;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] float playerSpeed = 1f;
    private bool _isGrounded = true;
    private Collider2D _collider2D;
    private Collider2D[] results;
    private bool _isOnLadder = false;
    private Vector2 tempPhysics;
    private Animator _animator;
    
    private void Awake()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
        results = new Collider2D[5];
        tempPhysics = Physics2D.gravity;
    }

    private void CheckCollision()
    {
        _isGrounded = false;
        _isOnLadder = false;
        //We set size equal to character collider
        Vector2 size = _collider2D.bounds.size;
        size.y += 0.1f;
        // Below method will return amount of objects that overlap between character collider and other colliders
        int amount = Physics2D.OverlapBoxNonAlloc(transform.position,size,0f, results);

        for (byte i = 0; i < amount; i++)
        {
            GameObject hit = results[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Ground")) //Check if hit gameobject layer equals "Ground" that we assign to platforms
            {
                
                _isGrounded = hit.transform.position.y < transform.position.y;  //Check if that collides happens between platform game object and below center of collider
                Physics2D.IgnoreCollision(_collider2D,results[i],!_isGrounded); //Prevent to head bump, we ignore collision between first and second parameter when _isGrounded equals false
            }

            if (hit.layer == LayerMask.NameToLayer("Ladder"))
            {
                _isOnLadder = true;
            }
        }
    }

    private void SetAnimation()
    {
        if (_direction.x != 0f)
        {
            _animator.SetBool("isRunning",true);
        }
        else
        {
            _animator.SetBool("isRunning",false);
        }

        if (_direction.y > 0f && _isOnLadder)
        {
            _animator.SetBool("isClimbing",true);
        }
        else
        {
            _animator.SetBool("isClimbing",false);
        }
    }
    
    private void Update()
    {
        CheckCollision();
        SetAnimation();

        if (!GameManager._paused)
        {
            _direction.x = Input.GetAxis("Horizontal") * playerSpeed;
            if (_isOnLadder)
            {
                _direction.y = Input.GetAxisRaw("Vertical") * playerSpeed;
                Physics2D.gravity = Vector2.zero;
            }
            else if (_isGrounded)
            {
                _direction.y = Mathf.Max(_direction.y, -1f);
            }
            if (_isGrounded && Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector2.up * jumpForce;
            }else
            {
                Physics2D.gravity = tempPhysics;
                _direction += Physics2D.gravity * Time.deltaTime;
            }
        }

        if (_direction.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (_direction.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
    private void FixedUpdate()
    {
        _rb2.MovePosition(_rb2.position + _direction * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Barrel"))
        {
            enabled = false;
            FindObjectOfType<GameManager>().LevelFailed();
        }else if (col.gameObject.CompareTag("Win"))
        {
            enabled = false;
            FindObjectOfType<GameManager>().LevelComplete();
        }
    }
}
