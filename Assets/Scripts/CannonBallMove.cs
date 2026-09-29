using UnityEngine;

public class CannonBallMove : MonoBehaviour
{
    [Header("Cannonball Speed")]
    [SerializeField] private float cannonBallSpeed;

    [Header("CannonBall Lifetime")]
    [SerializeField] private float lifeTime = 1.0f;

    void Update()
    {
        transform.Translate(Vector2.left * cannonBallSpeed * Time.deltaTime);
    }
}
