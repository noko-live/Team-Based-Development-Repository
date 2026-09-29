using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [Header("Input Keyboards")]
    [SerializeField] private List<KeyCode> playersInput = new List<KeyCode>();

    [Header("Coroutine Timer")]
    [SerializeField] private float timeCycle = 3.0f;


    [Header("Player Display")]
    [SerializeField] private int activeKeyIndex = 0;
    [SerializeField] private TextMeshProUGUI activePlayerText;

    private void Start()
    {
        StartCoroutine(ChangePlayers(playersInput.ToArray()));
    }

    private IEnumerator ChangePlayers(KeyCode[] keys)
    {
        while (true)
        {
            // Select a random key index
            activeKeyIndex = Random.Range(0, keys.Length);

            Debug.Log("Active key: " + keys[activeKeyIndex]);

            activePlayerText.text = "Active Player: " + keys[activeKeyIndex].ToString();

            yield return new WaitForSeconds(timeCycle);
        }
    }

    private void Update()
    {
        // Only allow input from the active key
        if (Input.GetKeyDown(playersInput[activeKeyIndex]))
        {
            Debug.Log("Player " + playersInput[activeKeyIndex] + " pressed.");
        }
    }

    public KeyCode GetActiveKey()
    {
        return playersInput[activeKeyIndex];
    }
}
