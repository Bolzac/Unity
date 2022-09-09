using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public Vector3 horizontalMove;
    Animator animator;
    bool isOnGround;
    // Start is called before the first frame update
    void Awake()
    {
        horizontalMove = GetComponent<Player_Inputs>().horizontalMove;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        animator = GetComponent<PlayerControl>().animator;
        isOnGround = GetComponent<PlayerControl>().isOnGround;
    }

    void FixedUpdate()
    {
        MoveHorizantal();
    }

    void MoveHorizantal()
    {
        transform.position += horizontalMove * speed * Time.fixedDeltaTime;
    }

    void setAni()
    {
        if (isOnGround)
        {
            if (horizontalMove == new Vector3(0, 0, 0))
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool(name: "isMoving", false);
            }
        }
    }
}
