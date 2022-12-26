using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Stats PlayerStats;
    public Knight Knight;
    private GameObject[] _sideEntities;
    private void Awake()
    {
        Knight = new Knight();
        PlayerStats = new Stats(Knight.Health, isPlayer:true);
        _sideEntities = new GameObject[4]; // 0 -> up, 1 -> right, 2-> bottom, 3-> left
    }

    // Update is called once per frame
    void Update()
    {
        CheckSides();
    }

    private void CheckSides()
    {
        var position = gameObject.transform.position;
        RaycastHit2D entityUp = Physics2D.Raycast(position, Vector2.up * 2);
        RaycastHit2D entityRight = Physics2D.Raycast(position, Vector2.right);
        RaycastHit2D entityBottom = Physics2D.Raycast(position, Vector2.down * 2);
        RaycastHit2D entityLeft = Physics2D.Raycast(position, Vector2.left);
        _sideEntities[0] = entityUp.transform.gameObject;
        _sideEntities[1] = entityRight.transform.gameObject;
        _sideEntities[2] = entityBottom.transform.gameObject;
        _sideEntities[3] = entityLeft.transform.gameObject;
        Debug.DrawRay(position,Vector3.up * 2);
        Debug.DrawRay(position,Vector3.left);
        Debug.DrawRay(position,Vector3.right);
        Debug.DrawRay(position,Vector3.down * 2);
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
