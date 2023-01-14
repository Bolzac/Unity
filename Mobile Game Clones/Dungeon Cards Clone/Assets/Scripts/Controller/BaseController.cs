using System.Collections;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public BaseModel baseModel;
    
    public IEnumerator SetName()
    {
        yield return new WaitUntil((() => baseModel));
        baseModel.nameText.text = baseModel.dataObject.name;
    }
    
    public void SetPosition(int x, int y)
    {
        baseModel.x = x;
        baseModel.y = y;
        baseModel.positionText.text = $"{baseModel.x},{baseModel.y}";
    }
}