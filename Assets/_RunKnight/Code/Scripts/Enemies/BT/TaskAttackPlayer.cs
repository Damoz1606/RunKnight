using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttackPlayer : Node
{
    private Transform _transform;
    private Transform _lastTarget;
    private Animator _animator;
    private Health _targetHealth;
    private EnemyActionManager _enemyAction;
    private float _counter = 0;

    public TaskAttackPlayer(Transform transform)
    {
        this._transform = transform;
        this._animator = this._transform.GetComponent<Animator>();
        this._enemyAction = this._transform.GetComponent<EnemyActionManager>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)this.GetData("target-player");
        if (target != this._lastTarget)
        {
            this._targetHealth = target.GetComponent<Health>();
            this._lastTarget = target;
        }
        this._counter += Time.deltaTime;
        if (this._counter >= this._enemyAction.ActionCooldownTime)
        {
            bool isPlayerDead = this._targetHealth.TakeHit(this._enemyAction.ActionForce);
            this._animator.SetBool("Attack", false);
            this.ClearData("target-player");
            this._counter = 0;
        }

        this.state = NodeState.RUNNING;
        return this.state;
    }
}
