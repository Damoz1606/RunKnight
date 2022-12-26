using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAction : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CharacterEvent action;
    public void OnPointerClick(PointerEventData eventData)
    {
        EventManager.TriggerEvent(Channel.CHARACTER.ToString(), action.ToString(), null);
    }
}
