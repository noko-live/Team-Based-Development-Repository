using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectManager : MonoBehaviour
{
    public static PlayerSelectManager Instance { get; private set; }

    [Header("Player States (P1, P2, P3, P4)")]
    [Tooltip("True means the player participates in the minigames.")]
    [SerializeField] private bool[] activePlayers = new bool[4];

    public IReadOnlyList<bool> ActivePlayers => activePlayers;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (activePlayers.Length == 0)
        {
            activePlayers = new bool[4];
        }

        EnsureAtLeastOnePlayerIsActive();
    }

    public bool IsPlayerActive(int playerIndex)
    {
        if (!IsValidPlayerIndex(playerIndex))
        {
            return false;
        }

        return activePlayers[playerIndex];
    }

    public void SetPlayerActive(int playerIndex, bool isActive)
    {
        if (!IsValidPlayerIndex(playerIndex))
        {
            return;
        }

        activePlayers[playerIndex] = isActive;
    }

    public List<int> GetActivePlayerIndexes()
    {
        List<int> activePlayerIndexes = new List<int>();

        for (int playerIndex = 0; playerIndex < activePlayers.Length; playerIndex++)
        {
            if (activePlayers[playerIndex])
            {
                activePlayerIndexes.Add(playerIndex);
            }
        }

        return activePlayerIndexes;
    }


    //Helper Methods
    private void EnsureAtLeastOnePlayerIsActive()
    {
        for (int playerIndex = 0; playerIndex < activePlayers.Length; playerIndex++)
        {
            if (activePlayers[playerIndex])
            {
                return;
            }
        }

        activePlayers[0] = true;
    }

    private bool IsValidPlayerIndex(int playerIndex)
    {
        return playerIndex >= 0 && playerIndex < activePlayers.Length;
    }
}
