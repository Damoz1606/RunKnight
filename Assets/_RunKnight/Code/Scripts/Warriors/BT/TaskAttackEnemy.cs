using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttackEnemy : Node
{
    private Transform _transform;
    private WarriorActionManager _attack;

    private bool _isWaiting = false;
    private float _cooldownCounter = 0;

    public TaskAttackEnemy(Transform transform)
    {
        this._transform = transform;
        this._attack = this._transform.GetComponent<WarriorActionManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._isWaiting)
        {
            this._cooldownCounter += Time.deltaTime;
            if (this._cooldownCounter >= this._attack.ActionCooldownTime)
                this._isWaiting = false;
        }
        else
        {
            // Enemy is Dead stuff
            Debug.Log("Attack");
            this._isWaiting = true;
            this._cooldownCounter = 0;
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
