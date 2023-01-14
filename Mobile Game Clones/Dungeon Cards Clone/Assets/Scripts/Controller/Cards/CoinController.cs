using UnityEngine;
public class CoinController : VitalController
{
    private CoinModel _coinModel;
    private void Start()
    {
        _coinModel = baseModel as CoinModel;
        if (_coinModel) _coinModel.currentHealth = Random.Range(2, _coinModel.currentHealth);
    }
    
    public void OnDisable()
    {
        Destroy(gameObject);
    }
}