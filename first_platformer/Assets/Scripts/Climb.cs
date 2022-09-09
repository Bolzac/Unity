using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    [SerializeField] float climbSpeed = 2f;
    public bool isOnLatter;
    Rigidbody2D rigidbody2d;
    Vector3 verticalMove;
    Animator animator;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        verticalMove = GetComponent<Player_Inputs>().verticalMove;
    }
    void Update()
    {
        verticalMove = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        isOnLatter = GetComponent<PlayerControl>().isOnLatter;
        animator = GetComponent<PlayerControl>().animator;
        climbLatter();
        setClimbAni();
    }

    void climbLatter()
    {
        if (isOnLatter)
        {
            transform.position += verticalMove * climbSpeed * Time.fixedDeltaTime;
            rigidbody2d.velocity = new Vector2(0, 0);
        }
    }

    void setClimbAni()
    {
        if (isOnLatter)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", true);
            animator.SetBool("isChrouching", true);
            if (verticalMove.y != 0)
            {
                animator.SetBool("isClimbing", false);
            }
            else
            {
                animator.SetBool("isClimbing", true);
            }
        }
    }
}
