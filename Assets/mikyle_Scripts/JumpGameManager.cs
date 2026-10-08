using UnityEngine;

public class JumpGameManager : MonoBehaviour
{
    public static JumpGameManager Instance { get; private set; }

    [Header("Player Scores")]
    [SerializeField] private int[] playerScores = new int[4];

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (playerScores.Length != 4)
        {
            playerScores = new int[4];
        }
    }

    public void AddPoint(int playerIndex)
    {
        if (!IsValidPlayerIndex(playerIndex))
        {
            return;
        }

        playerScores[playerIndex]++;

        Debug.Log(
            $"Player {playerIndex + 1} scored. " +
            $"Score: {playerScores[playerIndex]}"
        );
    }

    public void RegisterPlayerHit(int playerIndex)
    {
        if (!IsValidPlayerIndex(playerIndex))
        {
            return;
        }

        Debug.Log($"Player {playerIndex + 1} was hit by a cannonball.");
    }

    public int GetScore(int playerIndex)
    {
        if (!IsValidPlayerIndex(playerIndex))
        {
            return 0;
        }

        return playerScores[playerIndex];
    }

    private bool IsValidPlayerIndex(int playerIndex)
    {
        return playerIndex >= 0 && playerIndex < playerScores.Length;
    }
}