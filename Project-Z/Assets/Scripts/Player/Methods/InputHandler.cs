using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public KeyCode InteractInput;
    public float HorizontalInput;

    private void Update()
    {
        GetHorizontalInput();
    }

    private void GetInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractInput = KeyCode.E;
        }
    }

    private void GetHorizontalInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
