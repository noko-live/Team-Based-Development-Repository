using UnityEngine;

public class PlayerSelectMenu : MonoBehaviour
{
    [Header("Visual Indicators")]
    [Tooltip("Drag the GameObjects that show a player is active (e.g., Checkmarks, Borders) here. Index 0 is P1.")]
    public GameObject[] activeIndicators = new GameObject[4];

    private void Start()
    {
        // When the menu loads, make sure the visuals match the data
        RefreshAllIndicators();
    }

    // Method for UI Buttons to call when a player toggle button is pressed
    public void TogglePlayer(int playerIndex)
    {
        // Toggle the player's active state in the PlayerSelectManager
        bool currentState = PlayerSelectManager.Instance.IsPlayerActive(playerIndex);
        PlayerSelectManager.Instance.SetPlayerActive(playerIndex, !currentState);

        // Update the visual GameObject to match the new state
        activeIndicators[playerIndex].SetActive(!currentState);
    }

    private void RefreshAllIndicators()
    {
        for (int i = 0; i < activeIndicators.Length; i++)
        {
            if (activeIndicators[i] != null)
            {
                activeIndicators[i].SetActive(PlayerSelectManager.Instance.IsPlayerActive(i));
            }
        }
    }
}
