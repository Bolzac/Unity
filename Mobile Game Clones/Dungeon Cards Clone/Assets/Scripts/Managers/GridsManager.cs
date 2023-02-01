using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridsManager : MonoBehaviour
{
    public GridController gridController;
    private void Start()
    {
        gridController.InitTiles();
    }

}