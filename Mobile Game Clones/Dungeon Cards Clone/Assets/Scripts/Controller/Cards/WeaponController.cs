using UnityEngine;

public class WeaponController : FightController
{
    private WeaponModel _weaponModel;
    private void Start()
    {
        _weaponModel = baseModel as WeaponModel;
        if(_weaponModel) _weaponModel.currentHealth = Random.Range(2, _weaponModel.weaponData.health);
    }
}