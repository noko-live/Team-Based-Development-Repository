using UnityEngine;

public class CannonBallMove : MonoBehaviour
{
    [Header("Cannonball Stats")]
    [SerializeField] private float cannonBallSpeed = 5.0f;
    [SerializeField] private float lifeTime = 1.0f;

    [Header("Collision")]
    [Tooltip("Assign the normal, non-trigger cannonball collider.")]
    [SerializeField] private Collider2D cannonballCollider;

    private Rigidbody2D rb;
    private bool hasResolved;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.linearVelocity = -transform.right * cannonBallSpeed;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasResolved)
        {
            return;
        }

        PlayerJump playerJump =
            collision.gameObject.GetComponentInParent<PlayerJump>();

        if (playerJump != null)
        {
            hasResolved = true;
            playerJump.RegisterCannonballHit(); // Player is hit by the cannonball
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*  Second collider detect the player if they jump over cannonball. */

        if (hasResolved || cannonballCollider == null)
        {
            return;
        }

        PlayerJump playerJump = other.GetComponentInParent<PlayerJump>();

        if (playerJump == null)
        {
            return;
        }

        bool playerIsAboveCannonball = other.bounds.min.y > cannonballCollider.bounds.max.y;

        if (!playerIsAboveCannonball)
        {
            return;
        }

        hasResolved = true;
        playerJump.RegisterSuccessfulJump();
    }
}
