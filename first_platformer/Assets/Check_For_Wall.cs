using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_For_Wall : MonoBehaviour
{
    [SerializeField] BoxCollider2D Wall;
    public bool direction;
    void Update()
    {
        direction = Monster.direction;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && Wall.isTrigger)
        {
            Monster.direction = !direction;
        }
    }
}

//wall -- ground
//+    --  + (direction değişsin)
//-    --  +,- (direction sabit) (direction değişsin)