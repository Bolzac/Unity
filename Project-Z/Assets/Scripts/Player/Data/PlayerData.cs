using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "playerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("MoveState")] public float MoveSpeed = 5f;
    [Header("FaceDirection")] public bool isRight = true;
    [Header("FaceDirectionAnimation")] public bool isAnimationEnded = false;
}
