using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : Player
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Alarm")) return;
        CanInteract = true;
        Debug.Log(CanInteract);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Alarm")) return;
        CanInteract = false;
        Debug.Log(CanInteract);
    }
}