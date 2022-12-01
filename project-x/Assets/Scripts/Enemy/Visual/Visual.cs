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
    public static bool IsSeen = false;
    protected EnemyReactions _enemyReactions;

    private void Awake()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            _visualR = transform.Find("VisualR").gameObject;
            _visualL = transform.Find("VisualL").gameObject;
            _sliderR = _visualR.transform.Find("SliderR").gameObject;
            _sliderL = _visualL.transform.Find("SliderL").gameObject;
        }

        _enemyReactions = new EnemyReactions();
        _enemy = GetComponent<Enemy>();
        _direction = _enemy.direction;
    }

    private void Update()
    {
        _direction = _enemy.direction;
        SetVisualActive();
    }

    private void FixedUpdate()
    {
        SeePlayer();
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
        if (Player.IsVisible)
        {
            if (IsSeen && _slider && _slider.transform.localScale.x <= 1)
            {
                _slider.transform.localScale += new Vector3(0.005f, 0);
                _enemyReactions.SetQuestion(false,_enemy.QuestMark);
                _enemyReactions.SetExclamation(true,_enemy.ExclamationMark);
            }else if (!IsSeen && _slider && _slider.transform.localScale.x > 0 && _slider.transform.localScale.x < 1)
            {
                _slider.transform.localScale -= new Vector3(0.005f, 0);
                if (_slider.transform.localScale.x == 0 || _slider.transform.localScale.x <= 0.1f )
                {
                    _enemyReactions.SetExclamation(false,_enemy.ExclamationMark);
                    _enemyReactions.SetQuestion(true,_enemy.QuestMark);
                }
            }   
        }
    }
}
