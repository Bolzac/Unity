using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    
    public Vector2 currentPosition;
    
    public ScreenModel screenModel;

    [Header("Events")]
    #region Events

    public UnityEvent enemyShoot;

    #endregion

    [Header("States")]
    #region Conditions

    public bool isOnGround;

    public bool isOnWall;

    public bool isJumping;

    public bool isForceApplied;

    public bool isSlidingOnWall;

    #endregion

    [Header("Times")]
    #region Times

    public float onWallTime;
    public float maxStayFixedTimeOnWall;

    #endregion

    #region LineCast

    [HideInInspector] public int lineCastCount;
    public RaycastHit2D[] Results;

    #endregion

    [Header("GroundVariables")]
    #region GroundVariables

    public Transform ground;
    public Vector3 groundDetectLenght;

    #endregion

    [Header("SideVariables")]
    #region SideVariables

    public Transform leftSide;
    public Transform rightSide;
    public Vector3 sideDetectLenght;

    #endregion
}
