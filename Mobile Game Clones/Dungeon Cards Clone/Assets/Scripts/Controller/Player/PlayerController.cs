using UnityEngine;

public class PlayerController : DamageController
{
    private PlayerModel _playerModel;
    public InteractionController interactionController;

    private void Start()
    {
        _playerModel = baseModel as PlayerModel;
        InitializeCard();
    }
    
    private void GetHeal(int healAmount)
    {
        _playerModel.currentHealth = _playerModel.currentHealth + healAmount > _playerModel.playerData.health ? _playerModel.playerData.health : _playerModel.currentHealth + healAmount;
    }
    
    private void GetBlueHeal()
    {
        Debug.Log("Blue heal");
        if (_playerModel.playerData.blueDuration != 0)
        {
            _playerModel.currentHealth = _playerModel.currentHealth + _playerModel.potion.potionModel.currentHealth > _playerModel.playerData.health
                ? _playerModel.playerData.health
                : _playerModel.currentHealth + _playerModel.potion.potionModel.potionData.health;
            _playerModel.playerData.blueDuration--;
            if (_playerModel.playerData.blueDuration == 0)
            {
                _playerModel.potion = null;
                Destroy(_playerModel.potion);
                GameManager.Instance.OnRoundChange -= GetBlueHeal;
            }
        }
    }
    
    private void InitializeCard()
    {
        _playerModel.playerData.health = _playerModel.currentHealth;
        _playerModel.isWeaponEquipped = false;
        _playerModel.playerData.blueDuration = 0;
        SetPosition(1,1);
        StartCoroutine(SetName());
    }
    
    public bool AttackEnemy(Enemy enemy)
    {
        int damageAmount;
        if (!_playerModel.isWeaponEquipped)
        {                
            damageAmount = enemy.enemyModel.currentHealth > _playerModel.currentHealth
                ? _playerModel.currentHealth
                : enemy.enemyModel.currentHealth; ;
            TakeDamage(damageAmount);
            enemy.enemyController.TakeDamage(damageAmount);
            return true;
        }
        else
        {
            damageAmount = _playerModel.weapon.weaponModel.currentHealth;
            _playerModel.weapon.weaponController.TakeDamage(damageAmount);
            if (_playerModel.weapon.weaponModel.currentHealth == 0) _playerModel.isWeaponEquipped = false;
            if (damageAmount >= enemy.enemyModel.currentHealth) enemy.enemyModel.killedByWeapon = true;
            enemy.enemyController.TakeDamage(damageAmount);
            return false;
        }
    }
    
    public bool TakeWeapon(Weapon weap)
    {
        if(_playerModel.isWeaponEquipped) Destroy(_playerModel.weapon.gameObject);
        _playerModel.isWeaponEquipped = true;
        _playerModel.weapon = weap;
        return true;
    }
    
    public bool CollectCoin(int value)
    {
        _playerModel.goldAmount += value;
        GameManager.Instance.score = _playerModel.goldAmount;
        return true;
    }
    
    public bool TakePotion(Potion potionItem)
    {
        switch (potionItem.potionModel.potionData.type)
        {
            case PotionTypes.Red:
                GetHeal(potionItem.potionModel.currentHealth);
                GameManager.Instance.OnRoundChange -= TakePoisonDamage;
                GameManager.Instance.OnRoundChange -= GetBlueHeal;
                break;
            case PotionTypes.Blue:
                if(_playerModel.potion) Destroy(_playerModel.potion.gameObject);
                _playerModel.potion = potionItem;
                GameManager.Instance.OnRoundChange += GetBlueHeal;
                GameManager.Instance.OnRoundChange -= TakePoisonDamage;
                break;
            case PotionTypes.Poison: 
                if (_playerModel.currentHealth - potionItem.potionModel.currentHealth > 0)
                {
                    TakeDamage(potionItem.potionModel.currentHealth);
                    if(_playerModel.potion) Destroy(_playerModel.potion.gameObject);
                    _playerModel.potion = potionItem;
                    GameManager.Instance.OnRoundChange += TakePoisonDamage;
                    GameManager.Instance.OnRoundChange -= GetBlueHeal;
                }
                else _playerModel.currentHealth = 1;
                break;
        }

        return true;
    }
    
    public bool OpenChest(Chest chest)
    {
        chest.gameObject.SetActive(false);
        StaticMethods.Instance.SpawnNewCard(chest.baseModel.x, chest.baseModel.y, chest);
        Destroy(chest);
        return false;
    }
}