using System;
using System.Threading.Tasks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool CheckCanMove(Vector3 playerDirection, Vector3 onClicked, Player player)
    {
        if ((int)playerDirection.x == (int)onClicked.x
            && (int)playerDirection.y != (int)onClicked.y
            && Math.Abs(onClicked.y - playerDirection.y) <= 2.8)
        {
            player.playerModel.moveDirection = playerDirection.y > onClicked.y ? Direction.Down : Direction.Up;
            return true;
        }
        if (playerDirection.x != onClicked.x
            && playerDirection.y == onClicked.y
            && Math.Abs(onClicked.x - playerDirection.x) <= 1.4)
        {
            player.playerModel.moveDirection = playerDirection.x > onClicked.x ? Direction.Left : Direction.Right;
            return true;
        }
        return false;
    }

    public static async Task Move(Vector3 nextPoint, GameObject gameObject, float speed)
    {
        while (nextPoint != gameObject.transform.position)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, nextPoint,speed  * Time.deltaTime);
            await Task.Yield();
        }
    }
}