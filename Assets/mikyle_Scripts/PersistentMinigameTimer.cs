using System;
using UnityEngine;

public class PersistentMinigameTimer : MonoBehaviour
{
    public static PersistentMinigameTimer Instance { get; private set; }

    public event Action TimerFinished;

    public float RemainingTime { get; private set; }
    public bool IsRunning { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!IsRunning)
        {
            return;
        }

        RemainingTime -= Time.deltaTime;

        if (RemainingTime <= 0.0f)
        {
            RemainingTime = 0.0f;
            IsRunning = false;
            TimerFinished?.Invoke();
        }
    }

    public void StartTimer(float duration)
    {
        RemainingTime = Mathf.Max(0.0f, duration);
        IsRunning = RemainingTime > 0.0f;
    }

    public void StopTimer()
    {
        IsRunning = false;
    }

    public void ResetTimer()
    {
        RemainingTime = 0.0f;
        IsRunning = false;
    }
}