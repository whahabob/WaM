using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Place to initialize timers for the game
/// </summary>
public class WaMTimerManager : MonoBehaviour, IEventHandler<GameEndedEvent>
{
    private static WaMTimerManager instance;
    bool updating;
    public static WaMTimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<WaMTimerManager>();
                WaMEventSystem.Instance.Subscribe(instance);
            }
            return instance;
        }
    }

    private List<Timer> timers;

    private void Awake()
    {
        timers = new List<Timer>();
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        updating = true;
        for (int i = timers.Count - 1; i >= 0; i--)
        {
            timers[i].Update(deltaTime);

            if (timers[i].IsFinished)
            {

                OnTimerFinished(timers[i]);
                timers.RemoveAt(i);
            }
        }
        updating = false;
    }

    public void AddTimer(Timer timer)
    {
        timers.Add(timer);
       
    }

    public Timer AddTimer(int duration, Action callback)
    {
        Timer newTimer = new Timer(duration, callback);
        timers.Add(newTimer);
        return newTimer;
    }

    private void OnTimerFinished(Timer timer)
    {
        timer.Callback.Invoke();
        Debug.Log("Timer finished!");
    }

    public void OnEvent(GameEndedEvent args)
    {
        StartCoroutine(StopTimers());
    }

    private IEnumerator StopTimers()
    {
        yield return new WaitUntil(() => !updating);
        timers.Clear();
        yield return null;
    }
}
