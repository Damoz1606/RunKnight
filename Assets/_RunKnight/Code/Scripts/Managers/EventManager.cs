using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, UnityAction<object>>> _eventDictionary;
    private Dictionary<string, Dictionary<string, UnityAction<object>>> EventDictionary
    {
        get
        {
            if (this._eventDictionary == null)
                this._eventDictionary = new Dictionary<string, Dictionary<string, UnityAction<object>>>();
            return this._eventDictionary;
        }
    }

    /*     private static EventManager _instance;
        public static EventManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<EventManager>();
                _this.Initialize();
                return _instance;
            }
        }
     */

    public void StartListening(string channel, string listener, UnityAction<object> action)
    {
        Dictionary<string, UnityAction<object>> thisChannel = null;
        if (this.EventDictionary.TryGetValue(channel, out thisChannel))
        {
            UnityAction<object> thisEvent;
            if (thisChannel.TryGetValue(listener, out thisEvent))
            {
                thisEvent += action;
                thisChannel[listener] = thisEvent;
            }
            else
            {
                thisEvent += action;
                thisChannel.Add(listener, thisEvent);
            }
        }
        else
        {
            this.EventDictionary.Add(channel, new() { { listener, action } });
        }
    }

    public void StopListening(string channel, string listener, UnityAction<object> action)
    {
        Dictionary<string, UnityAction<object>> thisChannel;
        if (this.EventDictionary.TryGetValue(channel, out thisChannel))
        {
            UnityAction<object> thisEvent;
            if (thisChannel.TryGetValue(listener, out thisEvent))
            {
                thisEvent -= action;
                thisChannel[listener] = thisEvent;
            }
        }
    }

    public void TriggerEvent(string channel, string listener, object message)
    {
        Dictionary<string, UnityAction<object>> thisChannel = null;
        if (this.EventDictionary.TryGetValue(channel, out thisChannel))
        {
            UnityAction<object> thisEvent = null;
            if (thisChannel.TryGetValue(listener, out thisEvent))
            {
                thisEvent?.Invoke(message);
            }
        }
    }
}
