using System;
using System.Globalization;
using UnityEngine;

public class DragAndRelease : MonoBehaviour
{
    [SerializeField] private ScreenModel screenModel;

    public void CalculatePowerBar()
    {
        if (screenModel.playerModel.isJumping) return;
        
        screenModel.trajectoryLine.enabled = true;
        screenModel.dragLine.SetPosition(0, screenModel.clickPosition);
    }

    public void CalculateForce()
    {
        if (screenModel.playerModel.isJumping) return;
        
        screenModel.releasePosition = screenModel.camera.ScreenToWorldPoint(Input.mousePosition);
        if ((screenModel.clickPosition - screenModel.releasePosition).magnitude * screenModel.power > screenModel.minPower &&
            (screenModel.clickPosition - screenModel.releasePosition).magnitude * screenModel.power < screenModel.maxPower)
        {
            screenModel.force = (screenModel.clickPosition - screenModel.releasePosition) * screenModel.power;
        }
        screenModel.forceText.text = screenModel.force.magnitude.ToString(CultureInfo.CurrentCulture);
        screenModel.dragLine.SetPosition(1,screenModel.releasePosition);
    }
}