using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForGround : MonoBehaviour
{
    public BoxCollider2D GroundChecker;
    public bool direction;

    void Update()
    {
        direction = Monster.direction;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground" && GroundChecker.isTrigger)
        {
            Debug.Log("I am gonna fall!!");
            Monster.direction = !direction;
        }
    }
}
