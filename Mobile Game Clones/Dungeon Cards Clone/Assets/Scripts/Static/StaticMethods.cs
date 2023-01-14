using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class StaticMethods : MonoBehaviour
{
    public static StaticMethods Instance;
    [SerializeField] private Grid grid;
    
    [SerializeField] private int enemyLimit;
    [SerializeField] private int chestLimit;
    [SerializeField] private int trapLimit;
    [SerializeField] private int weaponLimit;

    public Base[] cards;
    public Base cardHolder;

    public EnemyObject[] enemyObjects;
    public WeaponObject[] weaponObjects;
    public PotionObject[] potionObjects;

    public int counter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        counter = 0;
    }

    public Base SpawnNewCard(int x, int y, Base card = null)
    {
        if (card)
        {
            if (card.CompareTag("Coin") || card.CompareTag("Player"))
            {
                StartCoroutine(card.baseController.SetName());
                card.baseController.SetPosition(x, y);
                SetCardArray((x,y),Instantiate(card, GetWorldPosition(x, y), quaternion.identity));
                return Card.cardArray[x, y];
            }
            if (card.CompareTag("Chest")) //chest kendini yolluyor
            {
                while (true)
                {
                    cardHolder = cards[Random.Range(0, cards.Length)];
                    if(!cardHolder.CompareTag("Chest")&& CheckForLimits(cardHolder) && card.baseModel.dataObject.isGood == cardHolder.baseModel.dataObject.isGood) break;
                }
                cardHolder.baseController.SetPosition(x, y);
                SetCardArray((x,y),Instantiate(cardHolder, GetWorldPosition(x, y), quaternion.identity));
                StartCoroutine(cardHolder.baseController.SetName());
                Destroy(card);
                return Card.cardArray[x, y];
            }
        }
        else
        {
            while (true)
            {
                cardHolder = cards[Random.Range(0, cards.Length)];
                if(CheckForLimits(cardHolder)) break;
            }
            SetCardArray((x,y),Instantiate(cardHolder,GetWorldPosition(x, y),quaternion.identity));
            StartCoroutine(Card.cardArray[x,y].baseController.SetName());
            Card.cardArray[x,y].baseController.SetPosition(x,y);
            return Card.cardArray[x,y];
        }

        return null;
    }
    private bool CheckForLimits(Base item)
    {
        bool state;
        switch (item.tag)
        {
            case "Enemy":
                CheckItems(item.tag);
                state = counter < enemyLimit;
                if (state)
                {
                    var enemy = ChooseEnemy();
                    ((Enemy)cardHolder).enemyModel.enemyData = enemy;
                    cardHolder.baseModel.dataObject = enemy;
                }
                counter = 0;
                return state;
            case "Weapon":
                CheckItems(item.tag);
                state = counter < weaponLimit;
                if (state)
                {
                    var weapon = ChooseWeapon();
                    ((Weapon)cardHolder).weaponModel.weaponData = weapon;
                    cardHolder.baseModel.dataObject = weapon;
                }
                counter = 0;
                return state;
            case "Chest":
                CheckItems(item.tag);
                state = counter < chestLimit;
                counter = 0;
                return state;
            case "Trap":
                CheckItems(item.tag);
                state = counter < trapLimit;
                counter = 0;
                return state;
            case "Potion":
                var potion = ChoosePotion();
                ((Potion)cardHolder).potionModel.potionData = potion;
                cardHolder.baseModel.dataObject = potion;
                return true;
        }
        return true;
    }

    private void CheckItems(string itemTag)
    {
        for (var i = 0; i < Card.cardArray.GetLength(0); i++)
        {
            for (var j = 0; j < Card.cardArray.GetLength(1); j++)
            { 
                if(Card.cardArray[i,j] == null) break;
                if (Card.cardArray[i,j].CompareTag(itemTag)) counter++;
            }
        }
    }

    private EnemyObject ChooseEnemy()
    {
        return enemyObjects[Random.Range(0, enemyObjects.Length)];
    }
    
    private WeaponObject ChooseWeapon()
    {
        return weaponObjects[Random.Range(0, weaponObjects.Length)];
    }
    
    private PotionObject ChoosePotion()
    {
        return potionObjects[Random.Range(0, potionObjects.Length)];
    }
    
    
    //----------------------------------------------------------------
    
    public void SetCardArray((int x, int y) gridPosition, Base tile)
    {
        tile.baseController.SetPosition(gridPosition.x,gridPosition.y);
        Card.cardArray[gridPosition.x, gridPosition.y] = tile;
    }

    public Vector3 GetWorldPosition(float x, float y, bool isCamera = false)
    {
        if (isCamera) return new Vector3(x * grid.tileWidth, y * grid.tileHeight, z :-10) * grid.verticalSpace ;
        return new Vector3(x * grid.tileWidth , y * grid.tileHeight) * grid.verticalSpace;
    }
}