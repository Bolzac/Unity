using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public KeyCode InteractInput;
    public KeyCode HideInput;
    
    public KeyCode GetInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractInput = KeyCode.E;
        }

        return InteractInput;
    }

    public float GetHorizontalInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    
    public KeyCode GetHideInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            HideInput = KeyCode.F;
        }

        return HideInput;
    }
}
