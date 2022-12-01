using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReactions
{
    public void SetQuestion(bool check, GameObject go)
    {
        go.SetActive(check);
    }

    public void SetExclamation(bool check, GameObject go)
    {
        go.SetActive(check);
    }
}
