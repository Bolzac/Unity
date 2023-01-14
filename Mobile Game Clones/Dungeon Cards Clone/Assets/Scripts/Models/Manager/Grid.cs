using UnityEngine;

[CreateAssetMenu (fileName = "Grid Object", menuName = "Grid")]
public class Grid : ScriptableObject
{
     [SerializeField] public float gridWidth;
     [SerializeField] public float gridHeight;
     
     [SerializeField] public float tileWidth;
     [SerializeField] public float tileHeight;

     [SerializeField] public float verticalSpace;
     [SerializeField] public float horizontalSpace;
}