using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStaminaBeforeRun : Node
{
    private Transform _transform;
    private Stamina _stamina;
    private Animator _animator;
    private RunnerManager _runner;

    public CheckStaminaBeforeRun(Transform transform)
    {
        this._transform = transform;
        this._stamina = this._transform.GetComponent<Stamina>();
        this._animator = this._transform.GetComponent<Animator>();
        this._runner = this._transform.GetComponent<RunnerManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._stamina.CurrentStamina > 0)
        {
            this._animator.SetBool(AnimatorConstants.KNIGHT_GROUND, true);
            this._animator.SetInteger(AnimatorConstants.KNIGHT_STATE, 1);
            this._runner.StartSpeed();
            this.state = NodeState.SUCCESS;
            return this.state;
        }
        this._animator.SetBool(AnimatorConstants.KNIGHT_GROUND, false);
        this._animator.SetInteger(AnimatorConstants.KNIGHT_STATE, 0);
        this._runner.StopSpeed();
        this._runner.Run = false;
        this._animator.speed = 1;
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
