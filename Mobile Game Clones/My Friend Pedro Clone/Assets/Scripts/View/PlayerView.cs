using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private UnityEvent onGround;
    [SerializeField] private UnityEvent onWall;
    [SerializeField] private UnityEvent onJump;

    [SerializeField] private PlayerModel playerModel;



    private void Start()
    {
        playerModel.Results = new RaycastHit2D[20];
    }

    private void Update()
    {
        SetCasts();
    }

    private void SetCasts()
    {
        playerModel.lineCastCount = Physics2D.LinecastNonAlloc(playerModel.ground.position, playerModel.ground.position + playerModel.groundDetectLenght, playerModel.Results);
        if (playerModel.lineCastCount > 1 && playerModel.Results[1].transform.CompareTag("Ground") && !playerModel.isOnGround)
        {
            if (playerModel.isInAir)
            {
                playerModel.isInAir = false;
                if (playerModel.isForceApplied)
                {
                    playerModel.isForceApplied = false;
                    SoundPlayer.Instance.PlayFall();
                }
            }
            onGround.Invoke();
        }else if (playerModel.lineCastCount <= 1)
        {
            playerModel.isOnGround = false;
        }

        if(playerModel.isOnGround) return;

        playerModel.lineCastCount = Physics2D.LinecastNonAlloc(playerModel.leftSide.position,playerModel.leftSide.position - playerModel.sideDetectLenght ,
            playerModel.Results,LayerMask.GetMask("World"));

        if (playerModel.lineCastCount > 1 && playerModel.Results[1].transform.CompareTag("Wall") && !playerModel.isOnWallFromLeft && !playerModel.isOnWallFromRight && !playerModel.isOnWall)
        {
            if (playerModel.isInAir)
            {
                playerModel.isInAir = false;
                if (playerModel.isForceApplied)
                {
                    playerModel.isForceApplied = false;
                    SoundPlayer.Instance.PlayWall();
                }
            }
            playerModel.isOnWallFromLeft = true;
            onWall.Invoke();
        }else if (playerModel.lineCastCount <= 1 && !playerModel.isOnWallFromRight)
        {
            playerModel.isOnWallFromLeft = false;
            playerModel.onWallTime = 0;
        }

        if(playerModel.isOnWallFromLeft) return;
        
        playerModel.lineCastCount = Physics2D.LinecastNonAlloc(playerModel.rightSide.position,playerModel.rightSide.position + playerModel.sideDetectLenght ,
            playerModel.Results,LayerMask.GetMask("World"));

        if (playerModel.lineCastCount > 1 && playerModel.Results[1].transform.CompareTag("Wall") && !playerModel.isOnWall && !playerModel.isOnWallFromLeft && !playerModel.isOnWallFromRight)
        {
            if (playerModel.isInAir)
            {
                playerModel.isInAir = false;
                if (playerModel.isForceApplied)
                {
                    playerModel.isForceApplied = false;
                    SoundPlayer.Instance.PlayWall();
                }
            }
            playerModel.isOnWallFromRight = true;
            onWall.Invoke();
        }else if (playerModel.lineCastCount <= 1 && !playerModel.isOnWallFromLeft)
        {
            playerModel.isOnWallFromRight = false;
            playerModel.onWallTime = 0;
        }

        if (!playerModel.isOnWallFromLeft && !playerModel.isOnWallFromRight) playerModel.isOnWall = false;

        if (!playerModel.isOnGround && !playerModel.isOnWall && !playerModel.isInAir && !playerModel.isSlidingOnWall && playerModel.isForceApplied)
        {
            onJump.Invoke();
        }
    }
}
