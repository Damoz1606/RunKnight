using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameStarted : Node
{
    private Transform _transform;

    public CheckGameStarted(Transform transform)
    {
        this._transform = transform;
    }

    public override NodeState Evaluate()
    {
        if (Manager.GameManager.HasStarted)
            return NodeState.SUCCESS;
        return NodeState.FAILURE;
    }
}
