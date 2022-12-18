using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCharacterOnTarget : Node
{
    private Transform _transform;
    private TargetPositionManager _target;

    public CheckCharacterOnTarget(Transform transform)
    {
        this._transform = transform;
        WarriorTargetManager warriorTarget = this._transform.GetComponent<WarriorTargetManager>();
        this._target = warriorTarget.TargetTransform.GetComponent<TargetPositionManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._target.WarriorOnTarget == null || this._target.WarriorOnTarget.Equals(this._transform))
        {
            this.state = NodeState.SUCCESS;
            return this.state;
        }
        this.state = NodeState.FAILURE;
        return this.state;
    }
}
