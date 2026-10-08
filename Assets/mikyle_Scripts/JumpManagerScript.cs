using UnityEngine;

public class JumpManagerScript : MonoBehaviour
{
    [Header("Player Objects")]
    [Tooltip("Players are ordered as P1, P2, P3, and P4.")]
    [SerializeField] private GameObject[] playerObjects = new GameObject[4];

    [Header("Player Jump Keys")]
    [SerializeField] private KeyCode[] jumpKeys =
    {
        KeyCode.Z,
        KeyCode.V,
        KeyCode.M,
        KeyCode.Slash
    };

    private void Start()
    {
        ApplyPlayerStates();
    }

    private void ApplyPlayerStates()
    {
        for (int playerIndex = 0; playerIndex < playerObjects.Length; playerIndex++)
        {
            if (playerObjects[playerIndex] == null)
            {
                continue;
            }

            bool isPlayerActive = PlayerSelectManager.Instance != null &&
                                  PlayerSelectManager.Instance.IsPlayerActive(playerIndex);

            PlayerJump playerJump =
                playerObjects[playerIndex].GetComponentInChildren<PlayerJump>(true);

            if (playerJump != null)
            {
                playerJump.SetPlayerIndex(playerIndex);

                if (playerIndex < jumpKeys.Length)
                {
                    playerJump.SetJumpKey(jumpKeys[playerIndex]);
                }
            }

            playerObjects[playerIndex].SetActive(isPlayerActive);
        }
    }
}
