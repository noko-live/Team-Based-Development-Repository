using System.Collections.Generic;
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
    private readonly HashSet<PlayerJump> resolvedPlayers = new HashSet<PlayerJump>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (cannonballCollider == null)
        {
            cannonballCollider = GetComponent<Collider2D>();
        }
    }

    private void Start()
    {
        if (rb != null)
        {
            rb.linearVelocity = -transform.right * cannonBallSpeed;
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerJump playerJump =
            collision.gameObject.GetComponentInParent<PlayerJump>();

        if (playerJump == null || resolvedPlayers.Contains(playerJump))
        {
            return;
        }

        resolvedPlayers.Add(playerJump);
        playerJump.RegisterCannonballHit();

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cannonballCollider == null)
        {
            return;
        }

        PlayerJump playerJump =
            other.GetComponentInParent<PlayerJump>();

        if (playerJump == null || resolvedPlayers.Contains(playerJump))
        {
            return;
        }

        bool playerIsAboveCannonball =
            other.bounds.min.y > cannonballCollider.bounds.max.y;

        if (!playerIsAboveCannonball)
        {
            return;
        }

        resolvedPlayers.Add(playerJump);
        playerJump.RegisterSuccessfulJump();

        // Do not destroy the cannonball here.
        // Other players must still be able to jump over it.
    }
}
