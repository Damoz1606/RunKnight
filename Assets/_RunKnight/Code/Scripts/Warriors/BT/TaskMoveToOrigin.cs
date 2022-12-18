using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMoveToOrigin : Node
{
    private Transform _transform;
    private WarriorTargetManager _target;
    private RunnerManager _runner;

    public TaskMoveToOrigin(Transform transform)
    {
        this._transform = transform;
        this._target = this._transform.GetComponent<WarriorTargetManager>();
        this._runner = this._transform.GetComponent<RunnerManager>();
    }

    public override NodeState Evaluate()
    {
        if (Vector3.Distance(this._transform.position, this._target.Origin) > 0.01f)
        {
            this._transform.position = Vector3.MoveTowards(this._transform.position, this._target.Origin, _runner.Speed * 1 / this._runner.InitialSpeed * Time.deltaTime);
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
