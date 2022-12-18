using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDefendFromEnemyEvent : Node
{
    private Transform _transform;
    private WarriorActionManager _defend;

    public CheckDefendFromEnemyEvent(Transform transform)
    {
        this._transform = transform;
        this._defend = this._transform.GetComponent<WarriorActionManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._defend._action)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
