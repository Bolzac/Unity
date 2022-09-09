using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text text;
    public void setHealth(int health)
    {
        text.text = health.ToString();
    }
}
