using Random = UnityEngine.Random;
public class PotionController : FightController
{
    private PotionModel _potionModel;

    private void Start()
    {
        _potionModel = baseModel as PotionModel;
        if (_potionModel) _potionModel.currentHealth = Random.Range(2, _potionModel.potionData.health);
    }
}