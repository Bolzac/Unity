using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public bool Interaction(Base clicked, string type)
    {
        switch (type)
        {
            case "Enemy":
            {
                return playerController.AttackEnemy(clicked as Enemy);
            }
            case "Coin":
            {
                var a = clicked as Coin;
                return playerController.CollectCoin(a.coinModel.currentHealth);
            }
            case "Potion":
            {
                return playerController.TakePotion(clicked as Potion);
            }
            case "Weapon":
            {
                return playerController.TakeWeapon(clicked as Weapon);
            }
            case "Trap":
            {
                return true;
            }
            case "Chest":
            {
                return playerController.OpenChest(clicked as Chest);
            }
            case "Empty":
            {
                Debug.Log("Empty");
                return true;
            }
            default: return false;
        }
    }
}