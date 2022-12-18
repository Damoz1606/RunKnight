using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMoveToTarget : Node
{
    private Transform _transform;
    private WarriorTargetManager _target;

    public CheckMoveToTarget(Transform transform)
    {
        _transform = transform;
        this._target = this._transform.GetComponent<WarriorTargetManager>();
    }

    public override NodeState Evaluate()
    {
        if (_target._isMovingToTarget)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
