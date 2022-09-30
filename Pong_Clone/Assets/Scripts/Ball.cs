using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] float speed = 10.0f;

    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
        AddStartingForce();
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
