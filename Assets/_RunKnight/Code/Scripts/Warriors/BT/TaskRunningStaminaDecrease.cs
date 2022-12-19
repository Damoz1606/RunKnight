using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRunningStaminaDecrease : Node
{
    private Transform _transform;
    private Stamina _stamina;

    private bool _isWaiting;
    private float _counter = 0f;

    public TaskRunningStaminaDecrease(Transform transform)
    {
        this._transform = transform;
        this._stamina = this._transform.GetComponent<Stamina>();
    }

    public override NodeState Evaluate()
    {
        if (this._isWaiting)
        {
            this._counter += Time.deltaTime;
            if (this._counter >= this._stamina.WaitDecreaseTime)
                this._isWaiting = false;
        }
        else
        {
            this._stamina.DecreaseStamina();
            this._counter = 0;
            this._isWaiting = true;
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
