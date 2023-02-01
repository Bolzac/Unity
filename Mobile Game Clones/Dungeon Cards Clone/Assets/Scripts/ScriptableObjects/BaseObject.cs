using TMPro;
using UnityEngine;
[CreateAssetMenu (fileName = "Base Object", menuName = "Base")]
public class BaseObject : ScriptableObject
{
    public new string name;

    public bool isGood;
    
    public Sprite sprite;

    public Base emptyCard;

    public float speed = 3;
}