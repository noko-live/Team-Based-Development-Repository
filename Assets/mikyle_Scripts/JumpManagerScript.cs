using UnityEngine;

public class JumpManagerScript : MonoBehaviour
{
    [Header("Players Active")]
    [Tooltip("Indicates which players are active in this minigame.")]
    public GameObject[] activePlayers = new GameObject[4];
    private void Start()
    {
        for (int playerIndex = 0; playerIndex < 4; playerIndex++)
        {
            if (PlayerSelectManager.Instance.IsPlayerActive(playerIndex))
            {
                EnablePlayer(playerIndex);
            }
        }
    }

    private void EnablePlayer(int playerIndex)
    {
        // Activate player's body as it loops through Instance
        if (activePlayers[playerIndex] != null)
        {
            for (int i =  0; i < activePlayers.Length; i++)
            {
                activePlayers[i].SetActive(true);
            }
        }
        
        Debug.Log($"Player {playerIndex + 1} is active in this minigame.");
    }
}
