using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNoRunningHealthDecrease : Node
{
    private Transform _transform;
    private Health _health;

    private bool _isWaiting;
    private float _cooldownCounter = 0f;

    public TaskNoRunningHealthDecrease(Transform transform)
    {
        this._transform = transform;
        this._health = this._transform.GetComponent<Health>();
    }

    public override NodeState Evaluate()
    {
        if (this._isWaiting)
        {
            this._cooldownCounter += Time.deltaTime;
            if (this._cooldownCounter >= this._health.WaitDecreaseTime)
                this._isWaiting = false;
        }
        else
        {
            this._health.DecreaseHealth();
            this._cooldownCounter = 0;
            this._isWaiting = true;
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
