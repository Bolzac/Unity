using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Weapon Object", menuName = "Weapon")]
public class WeaponObject : BaseObject
{
    public int health;
    public WeaponElements element;
    public WeaponTypes type;
}
