using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerModel : VitalModel
{
    public PlayerObject playerData;

    public bool isWeaponEquipped;
    
    public Weapon weapon;
    
    public Potion potion;

    public Direction moveDirection;
    
    public int goldAmount;
    
    public TextMeshPro weaponText;
}

public enum Direction
{
    Right,
    Left,
    Up,
    Down
}