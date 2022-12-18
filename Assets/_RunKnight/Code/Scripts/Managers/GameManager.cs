using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _hasStarted = false;
    private StateManager _stateManager;
    private bool _isTargetOccupied;

    public bool IsGameOver { get => _isGameOver; set => _isGameOver = value; }
    public bool HasStarted { get => _hasStarted; set => _hasStarted = value; }
    public bool IsTargetOccupied { get => _isTargetOccupied; set => _isTargetOccupied = value; }

    private void Awake()
    {
        this._stateManager = this.GetComponent<StateManager>();
        this._isGameOver = false;
    }

    private void Start()
    {
        this._stateManager.SetState(GameState.PLAY);
    }

    private void Update()
    {
        if (this._stateManager.CurrentState != null)
            this._stateManager.CurrentState.OnUpdate();
    }


}
