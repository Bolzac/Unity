using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Object : MonoBehaviour
{
    public void Flip(bool direction)
    {
        Vector3 lTemp = transform.localScale;
        if (direction)
        {
            if (lTemp.x == -1)
            {
                lTemp.x *= -1;
            }
            transform.localScale = lTemp;
        }
        else
        {
            if (lTemp.x == 1)
            {
                lTemp.x *= -1;
            }
            transform.localScale = lTemp;
        }
    }
}
