using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Player player;

    public void InitTiles()
    {
        Card.cardArray = new Base[(int)grid.gridWidth,(int)grid.gridHeight];
        for (var i = 0; i < grid.gridWidth; i++)
        {
            for (var j = 0; j < grid.gridHeight; j++)
            {
                if (i == 1 && j == 1) Card.cardArray[i, j] = StaticMethods.Instance.SpawnNewCard(i, j,player);
                else Card.cardArray[i, j] = StaticMethods.Instance.SpawnNewCard(i,j);
            }
        }

        if (Camera.main != null)
        {
            Camera.main.transform.position =
                StaticMethods.Instance.GetWorldPosition(1, 1, isCamera:true);   
        }
    }
}