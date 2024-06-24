
using System;
using UnityEngine;
/// <summary>
/// Custom timer with Integers instead of floats, once timer finished perform callback
/// </summary>
public class Timer
{
    public Action Callback;
    public int Duration { get; private set; }
    public int ElapsedTime { get; private set; }
    private float elapsedTime;
    public bool IsActive { get; private set; }
    public bool IsFinished => ElapsedTime >= Duration;

    public Timer(int duration, Action callback)
    {
        Duration = duration;
        ElapsedTime = 0;
        IsActive = true;
        Callback = callback;
    }

    public void Update(float deltaTime)
    {
        if (!IsActive) return;

        elapsedTime += deltaTime;
        ElapsedTime = Mathf.CeilToInt(elapsedTime);
        if (ElapsedTime >= Duration)
        {
            IsActive = false;
        }
    }

    public void Reset()
    {
        ElapsedTime = 0;
        IsActive = true;
    }

    public void Stop()
    {
        IsActive = false;
    }
}