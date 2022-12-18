using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        Manager.EventManager.TriggerEvent(Channel.CHARACTER.ToString(), CharacterEvent.RUN.ToString(), false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Manager.EventManager.TriggerEvent(Channel.CHARACTER.ToString(), CharacterEvent.RUN.ToString(), true);
    }
}
