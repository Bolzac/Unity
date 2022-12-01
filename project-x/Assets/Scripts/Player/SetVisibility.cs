using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisibility : Player
{
    [SerializeField] private GameObject visibilityOn;
    [SerializeField] private GameObject visibilityOff;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _ownSpriteRenderer;
    private Color _color;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Hide")) return;
        CanHide = true;
        _spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Hide")) return;
        CanHide = false;
        IsVisible = true;
    }

    private void Awake()
    {
        _ownSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (CanHide)
        {
            ToggleVisibility();
        }
        ToggleIcon();
        SetLayer();
    }
    private void ToggleVisibility()
    {
        {
            if (Input.GetKeyDown(KeyCode.E) && !IsVisible)
            {
                IsVisible = true;
            }else if (Input.GetKeyDown(KeyCode.E) && IsVisible)
            {
                IsVisible = false;
            }
        }
    }
    private void ToggleIcon()
    {
        if (IsVisible)
        {
            visibilityOn.SetActive(true);
            visibilityOff.SetActive(false);
        }
        else
        {
            visibilityOn.SetActive(false);
            visibilityOff.SetActive(true);
        }
    }

    private void SetLayer()
    {
        if (!_spriteRenderer) return;
        var r = _color.r;
        var g = _color.g;
        var b = _color.b;
        _spriteRenderer.color = !IsVisible ? new Color(r, g, b, 0.5f) : new Color(r, g, b, 1f);
        _ownSpriteRenderer.sortingOrder = !IsVisible ? -101 : 101;
    }
}