using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Arrow with cooldown
    //Freeze Y axis and velocity X axis
    //on collide with enemy destroy() enemy
    public bool onAtt = false;
    public GameObject arrow;
    [SerializeField] float arrowSpeed = 5f;
    float endpoint;
    Vector3 position;
    bool characterDirection;
    Animator animator;
    void Awake()
    {
        characterDirection = GetComponent<Flip>().characterDirection;
        animator = GetComponent<PlayerControl>().animator;
    }
    void Update()
    {
        characterDirection = GetComponent<Flip>().characterDirection;
        if (characterDirection) position = new Vector3(transform.position.x + 0.8f, transform.position.y - 0.4f, 0);
        else position = new Vector3(transform.position.x - 0.8f, transform.position.y - 0.4f, 0);
        if (Input.GetKeyDown(KeyCode.P) && !onAtt)
        {
            setEndPoint();
        }
        if (!onAtt) arrow.transform.position = position;
        arrow.GetComponent<Flip_Object>().Flip(characterDirection);
    }
    public void AttackP(bool onAttack)
    {
        onAtt = onAttack;
        if (onAtt)
        {
            if (characterDirection) arrow.transform.position += new Vector3(arrowSpeed * Time.deltaTime, 0, 0);
            else arrow.transform.position += new Vector3(-arrowSpeed * Time.deltaTime, 0, 0);
            arrow.SetActive(true);
            animator.SetBool("isAttacked", false);
        }
        else
        {
            arrow.SetActive(false);
            animator.SetBool("isAttacked", true);
        }
        if (characterDirection)
        {
            if (arrow.transform.position.x > endpoint)
            {
                onAtt = false;
                arrow.transform.position = position;
            }
        }
        else
        {
            if (arrow.transform.position.x < endpoint)
            {
                onAtt = false;
                arrow.transform.position = position;
            }
        }
    }

    void setEndPoint()
    {
        if (characterDirection) endpoint = arrow.transform.position.x + 2;
        else endpoint = arrow.transform.position.x - 2;
    }
}