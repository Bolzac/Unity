using System;
using UnityEngine;

public class ClickableCard : MonoBehaviour
{
    public static event Action<Base> OnAnyCardClicked = delegate { };
    public Base tile;
    public static bool canClick;

    private void Start()
    {
        canClick = true;
    }

    private void OnMouseDown()
    {
        if(canClick) OnAnyCardClicked(tile);
    }
}