using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ConditionController : MonoBehaviour
{
    [SerializeField] private ScreenModel screenModel;

    public void OnClick()
    {
        screenModel.clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (screenModel.clickPosition.x > screenModel.playerModel.currentPosition.x)
        {
            screenModel.isClickedOnLeft = false;
            screenModel.isClickedOnRight = true;
        }
        else
        {
            screenModel.isClickedOnLeft = true;
            screenModel.isClickedOnRight = false;
        }
    }

    public void OffClick()
    {
        screenModel.dragLine.SetPositions(new []{Vector3.zero,Vector3.zero});
        screenModel.trajectoryLine.enabled = false;
        screenModel.force = Vector2.zero;
        screenModel.forceText.text = screenModel.force.magnitude.ToString(CultureInfo.CurrentCulture);
        screenModel.time = 0;
        screenModel.timeText.text = screenModel.time.ToString(CultureInfo.CurrentCulture);
        screenModel.playerModel.rigidbody2D.gravityScale = 1;
    }
}