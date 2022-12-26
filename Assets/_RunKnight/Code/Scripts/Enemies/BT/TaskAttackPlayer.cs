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
    private bool _isWaiting = false;

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
        if (this._isWaiting)
        {
            this._counter += Time.deltaTime;
            if (this._counter >= this._enemyAction.ActionCooldownTime)
            {
                this._animator.SetBool("Attack", false);
                this.ClearData("target-player");
                Manager.SpawnManager.Kill(this._transform.GetComponent<EnemyManager>());
            }
        }
        else
        {
            this._animator.SetBool("Attack", true);
            this._targetHealth.TakeHit(this._enemyAction.ActionForce);
            this._counter = 0;
            this._isWaiting = true;
            Debug.Log("Player Hurt");
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
