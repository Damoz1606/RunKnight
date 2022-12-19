using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMoveRoadDeactivate : Node
{
    private Transform _transform;
    private EndlessRoad _road;
    private RunnerManager _runner;

    public TaskMoveRoadDeactivate(Transform transform, EndlessRoad road)
    {
        this._transform = transform;
        this._road = road;
        this._runner = this._transform.GetComponent<RunnerManager>();
    }

    public override NodeState Evaluate()
    {
        this._road.SpeedRoad = 0;
        this._road.ActiveRoad = false;
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
