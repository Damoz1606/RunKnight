using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRun : Node
{
    private Animator _animator;
    private Transform _transform;
    private RunnerManager _runner;
    private float _counter = 0;
    private bool _isWaiting = false;

    public TaskRun(Transform transform)
    {
        this._transform = transform;
        this._animator = this._transform.GetComponent<Animator>();
        this._runner = this._transform.GetComponent<RunnerManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._isWaiting)
        {
            this._counter += Time.deltaTime;
            if (this._counter >= this._runner.IncrementTime)
                this._isWaiting = false;
        }
        else
        {
            this._counter = 0f;
            this._isWaiting = true;
            this._animator.SetBool(AnimatorConstants.KNIGHT_GROUND, true);
            this._animator.SetInteger(AnimatorConstants.KNIGHT_STATE, 1);
            this._runner.IncrementSpeed();
            this._animator.speed = this._runner.Speed * 1 / this._runner.InitialSpeed;
        }

        return NodeState.RUNNING;
    }
}
