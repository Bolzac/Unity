using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    Vector3 horizontalMove;
    public bool characterDirection = true;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = GetComponent<Movement>().horizontalMove;
        Vector3 lTemp = transform.localScale;
        if (horizontalMove.x == -1)
        {
            characterDirection = false;
            if (lTemp.x == 1)
            {
                lTemp.x *= -1;
            }
            transform.localScale = lTemp;
        }
        else if (horizontalMove.x == 1)
        {
            characterDirection = true;
            if (lTemp.x == -1)
            {
                lTemp.x *= -1;
            }
            transform.localScale = lTemp;
        }
    }
}
