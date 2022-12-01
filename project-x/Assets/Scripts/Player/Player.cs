using UnityEngine;

public class Player : MonoBehaviour
{
    private float _moveSpeed = 1.5f;
    protected Rigidbody2D Rb2;
    protected Vector2 CurrentPosition;
    protected float Movespeed
    {
        get => _moveSpeed;
        set
        {
            if (value <= 3 && value >= 0)
            {
                _moveSpeed = value;
            }
        }
    }
    private bool _isRight = true;
    private Vector2 _direction;
    protected Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
        }
    [HideInInspector] public static bool IsVisible = true;
    protected bool CanHide = false;
    public static bool CanInteract = false;
    protected static bool IsRunning = false;
    private CreateSound _createSound;
    private float Loudness { get; } = 1f;
    private float _timeRemaining = 0f;
    private bool _timerIsRunning = false;

    private void Awake()
    {
        _createSound = new CreateSound();
    }

    private void Update()
    {
        DetectInput();
        DetectDirection();
        SoundTimer();
    }

    private void DetectInput()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (Input.GetKeyDown(KeyCode.LeftShift) && _direction.x != 0)
        {
            Movespeed =  3*Time.fixedDeltaTime;
            IsRunning = true;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Movespeed = 1.5f *Time.fixedDeltaTime;
            IsRunning = false;
        }
    }

    private void DetectDirection()
    {
        if (_direction.x >0)
        {
            transform.localRotation = new Quaternion(0, 0, 0,0);
        }else if (_direction.x < 0)
        {
            transform.localRotation = new Quaternion(0, 180, 0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (IsVisible)
        {
            if (col.CompareTag("Vision"))
            {
                Visual.IsSeen = true;
            }   
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsVisible)
        {
            if (other.CompareTag("Vision"))
            {
                Visual.IsSeen = true;
            }   
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Vision"))
        {
            Visual.IsSeen = false;
        }
    }

    private void SoundTimer()
    {
        if (IsRunning)
        {
            _timerIsRunning = true;
        }
        else
        {
            _timerIsRunning = false;
            _timeRemaining = 0;
        }

        if (_timerIsRunning)
        {
            _timeRemaining += Time.deltaTime;
        }

        if (Mathf.FloorToInt(_timeRemaining % 60) % 1 == 0 && _timeRemaining != 0)
        {
            _createSound.Create(gameObject,Loudness);
        }
    }
}