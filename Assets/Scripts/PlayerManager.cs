using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    [Header("Input Keyboards")]
    [SerializeField] private List<KeyCode> playersInput = new List<KeyCode>();

    [Header("Coroutine Timer")]
    [SerializeField] private float timeCycle = 3.0f;

    [SerializeField] private int activeKeyIndex = 0;

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
}
