using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRunEvent : Node
{
    private Animator _animator;
    private Transform _transform;
    private RunnerManager _runner;

    public CheckRunEvent(Transform transform)
    {
        this._transform = transform;
        this._animator = this._transform.GetComponent<Animator>();
        this._runner = this._transform.GetComponent<RunnerManager>();
    }

    public override NodeState Evaluate()
    {
        if (_runner.Run)
        {
            this._animator.SetBool(AnimatorConstants.KNIGHT_GROUND, true);
            this._animator.SetInteger(AnimatorConstants.KNIGHT_STATE, 1);
            this._runner.StartSpeed();
            return NodeState.SUCCESS;
        }
        this._animator.SetBool(AnimatorConstants.KNIGHT_GROUND, false);
        this._animator.SetInteger(AnimatorConstants.KNIGHT_STATE, 0);
        this._runner.StopSpeed();
        this._animator.speed = 1;
        return NodeState.FAILURE;
    }
}
