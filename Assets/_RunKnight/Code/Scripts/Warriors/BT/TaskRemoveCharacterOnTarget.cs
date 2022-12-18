using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRemoveCharacterOnTarget : Node
{
    private Transform _transform;
    private TargetPositionManager _target;
    private WarriorActionManager _warrior;

    public TaskRemoveCharacterOnTarget(Transform transform)
    {
        this._transform = transform;
        this._warrior = this._transform.GetComponent<WarriorActionManager>();
        WarriorTargetManager warriorTarget = this._transform.GetComponent<WarriorTargetManager>();
        this._target = warriorTarget.TargetTransform.GetComponent<TargetPositionManager>();
    }

    public override NodeState Evaluate()
    {
        if (Vector3.Distance(this._transform.position, this._target.transform.position) > 0.01f)
        {
            this._target.WarriorOnTarget = null;
            this._warrior.InTargetPosition = false;
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
