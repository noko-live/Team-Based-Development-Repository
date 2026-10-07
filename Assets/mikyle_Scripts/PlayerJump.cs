using UnityEngine;

public class PlayerJump : MonoBehaviour
{
        [Header("Jump Settings")]
        [Tooltip("Force applied when jumping.")]
        public float jumpForce = 5f;

        [Tooltip("Layers considered as ground.")]
        public LayerMask groundLayer;

        [Header("Ground Check")]
        [Tooltip("Position to check if player is grounded.")]
        public Transform groundCheck;
        [Tooltip("Radius of the ground check circle.")]
        public float groundCheckRadius = 0.2f;

        private Rigidbody2D rb;
        public bool isGrounded;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D missing! Please add one to the player. " + gameObject.name);
            }
        }

        void Update()
        {
            // Check if player is grounded
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            // Jump when space is pressed and player is grounded
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }

        /// <summary>
        /// Applies upward force to make the player jump.
        /// </summary>
        private void Jump()
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Draw ground check gizmo in editor
        void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
}
