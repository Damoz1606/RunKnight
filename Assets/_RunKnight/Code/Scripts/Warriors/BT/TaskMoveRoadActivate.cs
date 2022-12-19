using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMoveRoadActivate : Node
{
    private Transform _transform;
    private EndlessRoad _road;
    private RunnerManager _runner;

    public TaskMoveRoadActivate(Transform transform, EndlessRoad road)
    {
        this._transform = transform;
        this._road = road;
        this._runner = this._transform.GetComponent<RunnerManager>();
    }

    public override NodeState Evaluate()
    {
        this._road.SpeedRoad = this._runner.Speed;
        this._road.ActiveRoad = true;
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
