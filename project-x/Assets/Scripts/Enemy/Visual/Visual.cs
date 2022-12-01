using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual: MonoBehaviour
{
    private GameObject _visualR;
    private GameObject _visualL;
    private GameObject _slider;
    private GameObject _sliderR;
    private GameObject _sliderL;
    private Enemy _enemy;
    private int _direction;
    private Collider2D _collider2D;
    private Collider2D[] _collider2Ds;

    private void Awake()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            _visualR = transform.Find("VisualR").gameObject;
            _visualL = transform.Find("VisualL").gameObject;
            _sliderR = _visualR.transform.Find("SliderR").gameObject;
            _sliderL = _visualL.transform.Find("SliderL").gameObject;
        }

        _collider2D = GetComponent<Collider2D>();
        _enemy = GetComponent<Enemy>();
        _direction = _enemy.direction;
        _collider2Ds = new Collider2D[5];
    }

    private void Update()
    {
        _direction = _enemy.direction;
        SetVisualActive();
    }

    private void SetVisualActive()
    {
        switch (_direction)
        {
            case 1:
                _visualR.SetActive(true);
                _visualL.SetActive(false);
                _slider = _sliderR;
                break;
            case -1:
                _visualL.SetActive(true);
                _visualR.SetActive(false);
                _slider = _sliderL;
                break;
            default:
                _visualL.SetActive(false);
                _visualR.SetActive(false);
                break;
        }
    }

    private void SeePlayer()
    {
        var b = new ContactFilter2D().NoFilter();
        var a = Physics2D.OverlapCollider(_collider2D, b, _collider2Ds);
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(_collider2Ds[i]);
        }
    }
}
