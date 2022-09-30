using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Speed : MonoBehaviour
{
    [SerializeField] float bounceStrength = 5.0f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.rigidbody.AddForce(-normal, ForceMode2D.Impulse);
        }
    }
}
