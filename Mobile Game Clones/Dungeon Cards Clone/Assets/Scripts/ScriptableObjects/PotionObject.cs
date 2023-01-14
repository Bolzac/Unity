using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Potion Object", menuName = "Potion")]
public class PotionObject : BaseObject
{
    public int health;
    [SerializeField] public PotionTypes type;
}
