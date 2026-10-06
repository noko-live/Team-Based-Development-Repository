using UnityEngine;

public class CannonBallMove : MonoBehaviour
{
    [Header("CannonBall Stats")]
    [SerializeField] private float cannonBallSpeed = 5.0f;
    [SerializeField] private float lifeTime = 1.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = -transform.right * cannonBallSpeed;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
        }
        Destroy(gameObject);
        //No points for the player
    }
}
