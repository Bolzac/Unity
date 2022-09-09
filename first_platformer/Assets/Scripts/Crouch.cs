using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    [SerializeField] float crouchSpeed = 5f;
    bool isOnLatter;
    bool characterDirection;
    bool isOnGround;
    Rigidbody2D rigidbody2d;
    private float endPosition;
    public bool isChrouch;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = GetComponent<PlayerControl>().isOnGround;
        characterDirection = GetComponent<PlayerControl>().characterDirection;
        isOnLatter = GetComponent<PlayerControl>().isOnLatter;
        isChrouch = GetComponent<PlayerControl>().isChrouch;
        if (isOnGround)
        {
            CrouchForward();
        }
        if (isChrouch)
        {
            if (characterDirection)
            {
                if (transform.position.x >= endPosition)
                {
                    rigidbody2d.velocity = new Vector2(0, 0);
                    isChrouch = false;
                }
            }
            else
            {
                if (transform.position.x <= endPosition)
                {
                    rigidbody2d.velocity = new Vector2(0, 0);
                    isChrouch = false;
                }
            }
        }
    }

    void CrouchForward()
    {
        if (Input.GetKeyDown(KeyCode.S) && isOnGround && !isOnLatter)
        {
            if (characterDirection)
            {
                rigidbody2d.AddRelativeForce(new Vector2(1, 0) * crouchSpeed, ForceMode2D.Impulse);
                endPosition = transform.position.x + 2;
            }
            else if (!characterDirection)
            {
                rigidbody2d.AddRelativeForce(new Vector2(-1, 0) * crouchSpeed, ForceMode2D.Impulse);
                endPosition = transform.position.x - 2;
            }
            isChrouch = true;
        }
    }
}
