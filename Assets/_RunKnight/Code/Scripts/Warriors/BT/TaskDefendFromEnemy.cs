using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDefendFromEnemy : Node
{
    private Transform _transform;
    private WarriorActionManager _defend;

    private bool _isWaiting = false;
    private float _cooldownCounter = 0;

    public TaskDefendFromEnemy(Transform transform)
    {
        this._transform = transform;
        this._defend = this._transform.GetComponent<WarriorActionManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._isWaiting)
        {
            this._cooldownCounter += Time.deltaTime;
            if (this._cooldownCounter >= this._defend.ActionCooldownTime)
                this._isWaiting = false;
        }
        else
        {
            // Enemy is recoil stuff or obtacle destroy
            Debug.Log("Defend");
            this._isWaiting = true;
            this._cooldownCounter = 0;
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
