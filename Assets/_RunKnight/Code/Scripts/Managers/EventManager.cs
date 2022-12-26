using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, UnityAction<object>>> eventDictionary;

    private static EventManager eventManager;
    public static EventManager Instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    // Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Initialize();
                }
            }
            return eventManager;
        }
    }


    public void Initialize()
    {
        if (this.eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Dictionary<string, UnityAction<object>>>();
        }
    }


    /// <summary>
    /// Store a channel and it's event
    /// </summary>
    /// <param name="channelName"></param>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public static void StartListening(string channelName, string eventName, UnityAction<object> listener)
    {

        Dictionary<string, UnityAction<object>> thisChannel = null;
        if (Instance.eventDictionary.TryGetValue(channelName, out thisChannel))
        {
            UnityAction<object> thisEvent;
            if (thisChannel.TryGetValue(eventName, out thisEvent))
            {
                thisEvent += listener;
                thisChannel[eventName] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                thisChannel.Add(eventName, thisEvent);
            }
        }
        else
        {
            Instance.eventDictionary.Add(channelName, new() { { eventName, listener } });
        }
    }

    /// <summary>
    /// Stop listening an event with of a given channel
    /// </summary>
    /// <param name="channelName"></param>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public static void StopListening(string channelName, string eventName, UnityAction<object> listener)
    {
        if (eventManager == null) return;
        Dictionary<string, UnityAction<object>> thisChannel;
        if (Instance.eventDictionary.TryGetValue(channelName, out thisChannel))
        {
            UnityAction<object> thisEvent;
            if (thisChannel.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;
                thisChannel[eventName] = thisEvent;
            }
        }
    }

    /// <summary>
    /// Trigger an event of a given channel
    /// </summary>
    /// <param name="channelName"></param>
    /// <param name="eventName"></param>
    /// <param name="message"></param>
    public static void TriggerEvent(string channelName, string eventName, object message)
    {
        Dictionary<string, UnityAction<object>> thisChannel = null;
        if (Instance.eventDictionary.TryGetValue(channelName, out thisChannel))
        {
            UnityAction<object> thisEvent = null;
            if (thisChannel.TryGetValue(eventName, out thisEvent))
            {
                thisEvent?.Invoke(message);
            }
        }
    }
}
