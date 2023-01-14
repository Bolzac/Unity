using Random = UnityEngine.Random;

public class Chest : Base
{
    public ChestController chestController;
    public ChestModel chestModel;

    private void Start()
    {
        chestModel.dataObject.isGood = (Random.value > 0.5f);
        chestModel.dataObject.name = chestModel.dataObject.isGood ? "Good Chest" : "Bad Chest";
    }
}