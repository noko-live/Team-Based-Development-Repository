using UnityEngine;
using UnityEngine.InputSystem;

public class PopTheLockController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 150f;    

    [Header("Game Reference Visuals")]
    [SerializeField] private Transform targetDot; // The visual target marker
    [SerializeField] private float orbitRadius = 2.0f; // Distance of dot to center


    [Header("Mechanics")]
    [SerializeField] private float hitWindow = 12f; // The "hit window" size

    private float currentSpeed;
    private bool isClockwise = true;
    private float targetAngle;  
    private int score = 0;
    private bool isGameOver = false;

    private void Start()
    {
        ResetGameSettings();
    }

    private void Update()
    {
        if (isGameOver) return;

        // 1. Rotate the indicator around its center (Z-axis)
        float directionModifier = isClockwise ? -1f : 1f;
        transform.Rotate(Vector3.forward, currentSpeed * directionModifier * Time.deltaTime);
    }

    // 2. Called by the New Input System (Player Input Component)
    public void OnTap(InputAction.CallbackContext context)
    {
        // Only trigger on the initial press (started/performed state)
        if (!context.performed) return;

        if (isGameOver)
        {
            RestartGame();
            return;
        }

        CheckHit();
    }

    private void CheckHit()
    {
        // Get current rotation angle normalized between 0 and 360
        float currentAngle = transform.eulerAngles.z;

        // Calculate absolute difference between indicator and target angle
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));

        if (angleDifference <= hitWindow)
        {
            HandleHit();
        }
        else
        {
            GameOver();
        }
    }

    private void HandleHit()
    {
        score++;
        Debug.Log($"Hit! Current Score: {score}");

        // Reverse direction and spawn a new target point
        isClockwise = !isClockwise;
        SpawnNewTarget();
    }

    private void SpawnNewTarget()
{
    // 1. Pick a random target angle (0 to 360)
    targetAngle = Random.Range(0f, 360f);

    if (targetDot != null)
    {
        // 2. Add 90 degrees to align Trigonometry (3 o'clock) with Unity Rotation (12 o'clock)
        float visualAngle = targetAngle + 90f;
        float radians = visualAngle * Mathf.Deg2Rad;
        
        float x = Mathf.Cos(radians) * orbitRadius;
        float y = Mathf.Sin(radians) * orbitRadius;

        // 3. Move the target dot to the corrected location
        targetDot.position = new Vector3(x, y, 0f);
    }
}



    private void GameOver()
    {
        isGameOver = true;
        Debug.Log($"Game Over! Final Score: {score}. Tap again to restart.");
    }

    private void ResetGameSettings()
    {
        score = 0;
        currentSpeed = rotationSpeed;
        isClockwise = true;
        isGameOver = false;
        transform.rotation = Quaternion.identity; // Reset indicator position to top (0 degrees)
        SpawnNewTarget();
    }

    private void RestartGame()
    {
        ResetGameSettings();
    }
}
