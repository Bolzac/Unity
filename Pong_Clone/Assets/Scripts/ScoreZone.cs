using UnityEngine;
using UnityEngine.Events;

public class ScoreZone : MonoBehaviour
{
    public UnityEvent scoreTrigger;
    void OnCollisionEnter2D(Collision2D other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            scoreTrigger.Invoke();
        }
    }
}
