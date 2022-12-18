using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetCharacterOnTarget : Node
{
    private Transform _transform;
    private TargetPositionManager _target;
    private WarriorActionManager _warrior;

    public TaskSetCharacterOnTarget(Transform transform)
    {
        this._transform = transform;
        this._warrior = this._transform.GetComponent<WarriorActionManager>();
        WarriorTargetManager warriorTarget = this._transform.GetComponent<WarriorTargetManager>();
        this._target = warriorTarget.TargetTransform.GetComponent<TargetPositionManager>();
    }

    public override NodeState Evaluate()
    {
        if (Vector3.Distance(this._transform.position, this._target.transform.position) < 0.01f)
        {
            this._target.WarriorOnTarget = this._transform;
            this._warrior.InTargetPosition = true;
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
