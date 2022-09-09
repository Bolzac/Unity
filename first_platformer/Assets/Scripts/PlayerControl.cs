using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rigidbody2d;
    public bool characterDirection;
    public bool isOnGround = false;
    public bool isOnLatter = false;
    public bool isChrouch = false;
    public bool onAttack = false;
    [SerializeField] float force = 3;
    Vector3 startPoint;
    public int currentHealth;
    public int maxHealth = 3;
    public Health health;
    public Attack attack;

    void Start()
    {
        startPoint = transform.position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        health.setHealth(currentHealth);
    }
    void Update()
    {
        isChrouch = GetComponent<Crouch>().isChrouch;
        onAttack = GetComponent<Attack>().onAtt;
        characterDirection = GetComponent<Flip>().characterDirection;
        setAnimation();
        if (currentHealth == 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        if (Input.GetKeyDown(KeyCode.P)) onAttack = true;
        attack.AttackP(onAttack);
    }

    void setAnimation()
    {
        if (!isOnLatter)
        {
            if (isOnGround)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", true);
            }
            else if (!isOnGround)
            {
                if (rigidbody2d.velocity.y > 0)
                {
                    animator.SetBool("isJumping", false);
                }
                else
                {
                    animator.SetBool("isFalling", false);
                }
            }
        }
        if (isChrouch)
        {
            animator.SetBool("isChrouching", false);
        }
        else
        {
            animator.SetBool("isChrouching", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Water")
        {
            isOnGround = true;
        }

        if (other.tag == "Spike")
        {
            transform.SetPositionAndRotation(startPoint, new Quaternion(0, 0, 0, 0));
            currentHealth -= 1;
            health.setHealth(currentHealth);
        }

        if (other.tag == "latter")
        {
            isOnLatter = true;
            rigidbody2d.gravityScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isOnGround = false;
        }

        if (other.tag == "latter")
        {
            isOnLatter = false;
            rigidbody2d.gravityScale = 1;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "latter")
        {
            isOnLatter = true;
            rigidbody2d.gravityScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject.tag == "Enemy")
        {
            Vector2 dir = targetObj.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
            dir = -dir.normalized;
            rigidbody2d.AddForce(dir * force, ForceMode2D.Impulse);
            currentHealth -= 1;
            health.setHealth(currentHealth);
        }
    }
}