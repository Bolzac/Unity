using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rb2;
    [SerializeField] float moveSpeed = 2f;
    public static bool direction = true;

    void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Jump();
        Flip();
    }
    void Jump()
    {
        if (direction) rb2.velocity = new Vector2(moveSpeed, 0);
        if (!direction) rb2.velocity = new Vector2(-moveSpeed, 0);
    }

    void Flip()
    {
        Vector3 lTemp = transform.localScale;
        if (direction)
        {
            if (lTemp.x == -1)
            {
                lTemp.x = lTemp.x * -1;
            }
            transform.localScale = lTemp;
        }
        else
        {
            if (lTemp.x == 1)
            {
                lTemp.x = lTemp.x * -1;
            }
            transform.localScale = lTemp;
        }
    }
}