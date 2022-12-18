using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckThisCharacterOnTarget : Node
{
    private Transform _transform;
    private WarriorActionManager _warrior;

    public CheckThisCharacterOnTarget(Transform transform)
    {
        _transform = transform;
        this._warrior = this._transform.GetComponent<WarriorActionManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._warrior.InTargetPosition)
        {
            this.state = NodeState.SUCCESS;
            return this.state;
        }
        this.state = NodeState.FAILURE;
        return this.state;
    }
}
