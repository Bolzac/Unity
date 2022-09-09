using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inputs : MonoBehaviour
{
    public Vector3 verticalMove;
    public Vector3 horizontalMove;
    public KeyCode m_KeyCode;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            m_KeyCode = findInput();
        }
    }

    KeyCode findInput()
    {
        if (Input.GetKeyDown("space"))
        {
            return KeyCode.Space;
        }
        return new KeyCode();
    }
}
