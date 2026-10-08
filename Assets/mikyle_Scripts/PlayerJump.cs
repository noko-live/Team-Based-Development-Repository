using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private int playerIndex;

    [Header("Game Manager")]
    [SerializeField] private JumpGameManager jumpGameManager;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Header("Keyboard Input")]
    [SerializeField] private KeyCode jumpKey;

    [Header("Jump Events")]
    [SerializeField] private UnityEvent onSuccessfulJump;
    [SerializeField] private UnityEvent onCannonballHit;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb == null || groundCheck == null)
        {
            return;
        }

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    public void SetPlayerIndex(int index)
    {
        playerIndex = index;
    }

    public void SetJumpKey(KeyCode key)
    {
        jumpKey = key;
    }

    public void SetGameManager(JumpGameManager gameManager)
    {
        jumpGameManager = gameManager;
    }

    public void RegisterSuccessfulJump()
    {
        if (jumpGameManager != null)
        {
            jumpGameManager.AddPoint(playerIndex);
        }

        onSuccessfulJump?.Invoke();
    }

    public void RegisterCannonballHit()
    {
        if (jumpGameManager != null)
        {
            jumpGameManager.RegisterPlayerHit(playerIndex);
        }

        onCannonballHit?.Invoke();
    }

    private void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}
