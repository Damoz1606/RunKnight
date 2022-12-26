using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLetWarriorsRun : Node
{
    private Transform _transform;
    private PlayerManager _player;
    private RunnerManager _runnerAttack;
    private RunnerManager _runnerDefend;

    public TaskLetWarriorsRun(Transform transform)
    {
        _transform = transform;
        this._player = this._transform.GetComponent<PlayerManager>();
        this._runnerAttack = this._player.Attack.transform.GetComponent<RunnerManager>();
        this._runnerDefend = this._player.Defend.transform.GetComponent<RunnerManager>();
    }

    public override NodeState Evaluate()
    {
        if (!this._runnerAttack.Run) this._runnerAttack.Run = true;
        if (!this._runnerDefend.Run) this._runnerDefend.Run = true;

        this.state = NodeState.RUNNING;
        return this.state;
    }
}
