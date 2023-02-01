using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private UnityEvent onGround;
    [SerializeField] private UnityEvent onWall;

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
        Debug.DrawLine(playerModel.ground.position, playerModel.ground.position + playerModel.groundDetectLenght);
        for (int i = 0; i <playerModel.lineCastCount; i++)
        {
            if (playerModel.Results[i].transform.CompareTag("Ground"))
            {
                onGround.Invoke();
                if (playerModel.isJumping)
                {
                    playerModel.isJumping = false;
                    if (playerModel.isForceApplied)
                    {
                        playerModel.isForceApplied = false;
                        SoundPlayer.Instance.PlayFall();
                    }
                }
                break;
            }

            playerModel.isOnGround = false;
        }

        if(playerModel.isOnGround) return;

        playerModel.lineCastCount = Physics2D.LinecastNonAlloc(playerModel.leftSide.position,playerModel.leftSide.position - playerModel.sideDetectLenght ,
            playerModel.Results,LayerMask.GetMask("World"));

        Debug.DrawLine(playerModel.leftSide.position,playerModel.leftSide.position - playerModel.sideDetectLenght);
        
            if (playerModel.lineCastCount > 1 && playerModel.Results[1].transform.CompareTag("Wall"))
            {
                onWall.Invoke();
                if (playerModel.isJumping)
                {
                    playerModel.isJumping = false;
                    if (playerModel.isForceApplied)
                    {
                        playerModel.isForceApplied = false;
                        SoundPlayer.Instance.PlayWall();
                    }
                }
            }else if (playerModel.lineCastCount <= 1)
            {
                playerModel.isOnWall = false;
                playerModel.onWallTime = 0;
            }

            if(playerModel.isOnWall) return;
        
        playerModel.lineCastCount = Physics2D.LinecastNonAlloc(playerModel.rightSide.position,playerModel.rightSide.position + playerModel.sideDetectLenght ,
            playerModel.Results,LayerMask.GetMask("World"));
        
        Debug.DrawLine(playerModel.rightSide.position,playerModel.rightSide.position + playerModel.sideDetectLenght);

        if (playerModel.lineCastCount > 1 && playerModel.Results[1].transform.CompareTag("Wall"))
        {
            onWall.Invoke();
            if (playerModel.isJumping)
            {
                playerModel.isJumping = false;
                if (playerModel.isForceApplied)
                {
                    playerModel.isForceApplied = false;
                    SoundPlayer.Instance.PlayWall();
                }
            }
        }else if (playerModel.lineCastCount <= 1)
        {
            playerModel.isOnWall = false;
            playerModel.onWallTime = 0;
        }

        if (!playerModel.isOnGround && !playerModel.isOnWall && !playerModel.isJumping)
        {
            playerModel.isJumping = true;
            if (playerModel.isSlidingOnWall)
            {
                playerModel.isSlidingOnWall = false;
                playerModel.onWallTime = 0;
            }

            playerModel.rigidbody2D.gravityScale = 1;
        }
    }
}
