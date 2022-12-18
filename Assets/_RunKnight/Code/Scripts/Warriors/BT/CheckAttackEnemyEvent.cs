using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackEnemyEvent : Node
{
    private Transform _transform;
    private WarriorActionManager _attack;

    public CheckAttackEnemyEvent(Transform transform)
    {
        this._transform = transform;
        this._attack = this._transform.GetComponent<WarriorActionManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._attack._action)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
