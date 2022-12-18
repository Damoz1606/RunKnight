using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private _IState currentState;

    public _IState CurrentState { get => currentState; private set => currentState = value; }

    public void SetState(GameState newState)
    {
        if (this.CurrentState != null)
            this.CurrentState.OnDeactivate();

        this.CurrentState = GetComponentInChildren(this.GetState(newState)) as _IState;
        if (this.CurrentState != null)
            this.CurrentState.OnActivate();
    }

    private System.Type GetState(GameState state)
    {
        switch (state)
        {
            case GameState.PREPARE:
                return null;
            case GameState.PLAY:
                return typeof(PlayState);
            case GameState.GAMEOVER:
                return typeof(PlayState);
            case GameState.PAUSE:
                return typeof(PauseState);
            default:
                return null;
        }
    }
}
