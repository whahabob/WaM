using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// WaMEventSystem is used to Notify events through the application
/// New classes can be created to create new events
/// </summary>
public class WaMEventSystem
{
    private static WaMEventSystem instance;
    private Dictionary<Type, List<object>> eventTable = new Dictionary<Type, List<object>>();

    public static WaMEventSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WaMEventSystem();
            }
            return instance;
        }
    }
    
    public void Subscribe<T>(IEventHandler<T> handler)
    {
        Type eventType = typeof(T);
        if (!eventTable.ContainsKey(eventType))
        {
            eventTable[eventType] = new List<object>();
        }
        //Keep a list of all the handlers that want to be notified of specific event
        eventTable[eventType].Add(handler);
    }

    public void Unsubscribe<T>(IEventHandler<T> handler)
    {
        Type eventType = typeof(T);
        if (eventTable.ContainsKey(eventType))
        {
            eventTable[eventType].Remove(handler);
        }
    }

    public void Notify<T>(T args)
    {
        Type eventType = typeof(T);
        //If Event is found,, notify all handlers associated with that event
        if (eventTable.ContainsKey(eventType))
        {
            foreach (var handler in eventTable[eventType])
            {
                ((IEventHandler<T>)handler).OnEvent(args);
            }
        }
    }
}