using System;
using UnityEngine;
using UnityEngine.Events;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> onRelease;
    [SerializeField] private UnityEvent onClick;
    [SerializeField] private UnityEvent onDrag;
    [SerializeField] private UnityEvent fireGun;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick.Invoke();
        }else if (Input.GetMouseButton(0))
        {
            MouseDrag();
        }else if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    [SerializeField] private ScreenModel screenModel;

    private void MouseUp()
    {
        if(screenModel.isMouseHeldDown) onRelease.Invoke(screenModel.force);
        else fireGun.Invoke();
        
        screenModel.mouseTime = 0;
    }

    private void MouseDrag()
    {
        screenModel.mouseTime += 1;
        if (screenModel.mouseTime > 20)
        {
            screenModel.isMouseHeldDown = true;
            onDrag.Invoke();
        }
    }
}