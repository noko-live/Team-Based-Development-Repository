using System.Collections.Generic;
using UnityEngine;

public class JumpGameManager : MonoBehaviour
{
    [Header("Minigame Settings")]
    [SerializeField] private float minigameDuration = 30.0f;

    [Header("Player Scores")]
    [SerializeField] private int[] playerScores = new int[4];

    private bool gameHasEnded;

    private void Awake()
    {
        if (playerScores.Length != 4)
        {
            playerScores = new int[4];
        }
        else
        {
            System.Array.Clear(playerScores, 0, playerScores.Length);
        }
    }

    private void OnEnable()
    {
        if (PersistentMinigameTimer.Instance != null)
        {
            PersistentMinigameTimer.Instance.TimerFinished += EndMinigame;
        }
    }

    private void Start()
    {
        if (PersistentMinigameTimer.Instance == null)
        {
            Debug.LogError(
                "No PersistentMinigameTimer exists in the scene."
            );

            return;
        }

        PersistentMinigameTimer.Instance.StartTimer(minigameDuration);
    }

    private void OnDisable()
    {
        if (PersistentMinigameTimer.Instance != null)
        {
            PersistentMinigameTimer.Instance.TimerFinished -= EndMinigame;
        }
    }

    public void AddPoint(int playerIndex)
    {
        if (gameHasEnded || !IsValidPlayerIndex(playerIndex))
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
        if (gameHasEnded || !IsValidPlayerIndex(playerIndex))
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

    private void EndMinigame()
    {
        if (gameHasEnded)
        {
            return;
        }

        gameHasEnded = true;

        List<int> winners = GetWinners();

        if (winners.Count == 0)
        {
            Debug.Log("The minigame ended with no active players.");
            return;
        }

        if (winners.Count == 1)
        {
            int winnerIndex = winners[0];

            Debug.Log(
                $"Player {winnerIndex + 1} wins with " +
                $"{playerScores[winnerIndex]} points!"
            );

            return;
        }

        string tiedPlayers = string.Empty;

        foreach (int winnerIndex in winners)
        {
            if (tiedPlayers.Length > 0)
            {
                tiedPlayers += ", ";
            }

            tiedPlayers += $"Player {winnerIndex + 1}";
        }

        Debug.Log(
            $"The minigame ended in a tie between {tiedPlayers} " +
            $"with {playerScores[winners[0]]} points!"
        );
    }

    private List<int> GetWinners()
    {
        List<int> winners = new List<int>();
        int highestScore = int.MinValue;

        for (int playerIndex = 0; playerIndex < playerScores.Length; playerIndex++)
        {
            if (PlayerSelectManager.Instance != null && !PlayerSelectManager.Instance.IsPlayerActive(playerIndex))
            {
                continue;
            }

            if (playerScores[playerIndex] > highestScore)
            {
                highestScore = playerScores[playerIndex];
                winners.Clear();
                winners.Add(playerIndex);
            }
            else if (playerScores[playerIndex] == highestScore)
            {
                winners.Add(playerIndex);
            }
        }

        return winners;
    }

    private bool IsValidPlayerIndex(int playerIndex)
    {
        return playerIndex >= 0 && playerIndex < playerScores.Length;
    }
}