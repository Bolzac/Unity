using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMonster : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("hi");
        }
    }
}
