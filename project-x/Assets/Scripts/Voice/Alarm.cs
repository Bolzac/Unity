using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private CreateSound _createSound;
    private float Loudness = 3f;

    private void Awake()
    {
        _createSound = new CreateSound();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Player.CanInteract)
        {
            _createSound.Create(gameObject,Loudness);
        }
    }
}