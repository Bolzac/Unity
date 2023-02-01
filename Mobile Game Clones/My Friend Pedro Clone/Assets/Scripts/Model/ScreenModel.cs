using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenModel : MonoBehaviour
{
    [Header("UI")]
    #region UI Field
    
    public Text forceText;
    
    public Text timeText;

    #endregion

    [Header("Physics")]
    #region Force Variables

    public float power;
    public float minPower;
    public float maxPower;
    public Vector2 force;
    
    public float time;
    public float mass;
    
    #endregion
    
    [Header("Mouse Positions")]
    #region Mouse Positions
    
    public Vector2 clickPosition;
    public Vector2 releasePosition;

    #endregion

    [Header("Conditions")]
    #region MouseConditions

    public int mouseTime;
    public bool isMouseHeldDown;

    public bool isClickedOnRight;
    public bool isClickedOnLeft;

    #endregion

    [Header("Points")]
    #region Points

    public Vector3[] allPoints;
    public int pointCount;

    #endregion

    [Header("Others")]
    #region Others

    public new Camera camera;
    public PlayerModel playerModel;
    public LineRenderer dragLine;
    public LineRenderer trajectoryLine;

    #endregion

    private void Start()
    {
        mass = playerModel.rigidbody2D.mass;
    }
}
