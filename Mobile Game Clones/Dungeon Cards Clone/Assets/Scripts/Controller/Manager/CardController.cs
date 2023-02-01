using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private Card card;
    [SerializeField] private Movement movement;

    private void Awake()
    {
        ClickableCard.OnAnyCardClicked += OnClickedToCard;
        Player.OnPlayerBorn += AssignPlayer;
    }

    private void AssignPlayer(Player playerObj)
    {
        card.player = playerObj;
    }

    private async void OnClickedToCard(Base tile)
    {
        ClickableCard.canClick = false;
        card.clickedObject = tile;
        var player = card.player as Player;
        if (!movement.CheckCanMove(
                StaticMethods.Instance.GetWorldPosition(player.playerModel.x, player.playerModel.y),
                StaticMethods.Instance.GetWorldPosition(card.clickedObject.baseModel.x, card.clickedObject.baseModel.y),
                player
            ))
        {
            Debug.Log($"{card.clickedObject.baseModel.x},{card.clickedObject.baseModel.y}");
            ClickableCard.canClick = true;
            return;
        }
        if (player.playerController.interactionController.Interaction(card.clickedObject, card.clickedObject.tag))
        {
            card.followerCard = CheckFollowerCard(player);
            await ChangeCardDeck(player);
            GameManager.Instance.MoveNextRound();   
        }
        else GameManager.Instance.MoveNextRound();

        card.clickedObject = null;
        card.followerCard = null;
        ClickableCard.canClick = true;
    }

    private Base CheckFollowerCard(Player player)
    {
        var x = player.playerModel.x;
        var y = player.playerModel.y;
        switch (player.playerModel.moveDirection)
        {
            case Direction.Right:
                switch (x)
                {
                    case 1:
                        return Card.cardArray[x - 1, y];
                    case 0:
                        return y != 1 ? Card.cardArray[0,1] : Card.cardArray[0,2];
                }

                break;
            case Direction.Left:
                switch (x)
                {
                    case 1:
                        return Card.cardArray[x + 1, y];
                    case 2:
                        return y != 1 ? Card.cardArray[2,1] : Card.cardArray[2,0];
                }

                break;
            case Direction.Up:
                switch (y)
                {
                    case 1:
                        return Card.cardArray[x, y - 1];
                    case 0:
                        return x != 1 ? Card.cardArray[1,0] : Card.cardArray[2,0];
                }

                break;
            case Direction.Down:
                switch (y)
                {
                    case 1:
                        return Card.cardArray[x, y + 1];
                    case 2:
                        return x != 1 ? Card.cardArray[1,2] : Card.cardArray[0,2];
                }
                break;
            default:
                CheckFollowerCard(player);
                break;
        }
        return null;
    }
    private async Task ChangeCardDeck(Player player)
    {
        var nextGridOfPlayer = (card.clickedObject.baseModel.x,card.clickedObject.baseModel.y);
        var nextGridOfFollower = (player.playerModel.x, player.playerModel.y);
        var nextGridOfSpawned = (card.followerCard.baseModel.x,card.followerCard.baseModel.y);
        var nextPositionOfPlayer = StaticMethods.Instance.GetWorldPosition(nextGridOfPlayer.x, nextGridOfPlayer.y);
        var nextPositionOfFollower = StaticMethods.Instance.GetWorldPosition(nextGridOfFollower.x,nextGridOfFollower.y);
        card.clickedObject.gameObject.SetActive(false);
        await Movement.Move(nextPositionOfPlayer,card.player.gameObject, card.player.baseModel.dataObject.speed);
        if(!card.followerCard) Debug.Log("Yok");
        await Movement.Move(nextPositionOfFollower, card.followerCard.gameObject, card.followerCard.baseModel.dataObject.speed);
        player.playerController.SetPosition(nextGridOfPlayer.x,nextGridOfPlayer.y);
        var grids = new[]
        {
            nextGridOfPlayer,
            nextGridOfFollower
        };
        var gos = new[]
        {
            card.player,
            card.followerCard,
        };
        for (var i = 0; i < grids.Length; i++)
        {
            StaticMethods.Instance.SetCardArray(grids[i],gos[i]);
        }

        StaticMethods.Instance.SpawnNewCard(nextGridOfSpawned.x, nextGridOfSpawned.y);
    }
}