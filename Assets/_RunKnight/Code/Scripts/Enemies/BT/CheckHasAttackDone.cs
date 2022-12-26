using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHasAttackDone : Node
{
    private Transform _transform;
    private EnemyActionManager _action;

    public CheckHasAttackDone(Transform transform)
    {
        _transform = transform;
        this._action = this._transform.GetComponent<EnemyActionManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._action.Done)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
    }
}
