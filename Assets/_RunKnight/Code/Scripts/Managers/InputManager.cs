using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.TriggerEvent(Channel.CHARACTER.ToString(), CharacterEvent.ATTACK.ToString(), null);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            EventManager.TriggerEvent(Channel.CHARACTER.ToString(), CharacterEvent.DEFENSE.ToString(), null);
        }
    }
}
