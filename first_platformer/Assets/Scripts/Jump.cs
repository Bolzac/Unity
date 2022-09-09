using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    bool isOnGround;
    bool isOnLatter;
    [SerializeField] float jumpForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = GetComponent<PlayerControl>().isOnGround;
        isOnLatter = GetComponent<PlayerControl>().isOnLatter;
        if (!isOnLatter)
        {
            JumpUp();
        }
    }

    void JumpUp()
    {
        if (isOnGround && Input.GetKeyDown("space"))
        {
            rigidbody2d.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
        }
    }
}
