using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInAttackArea : Node
{
    private Transform _transform;
    private EnemyActionManager _enemyActionManager;
    private Animator _animator;

    public CheckPlayerInAttackArea(Transform transform)
    {
        this._transform = transform;
        this._enemyActionManager = this._transform.GetComponent<EnemyActionManager>();
        this._animator = this._transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = this.GetData("target-player");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
        Transform target = (Transform)t;
        if (Vector3.Distance(this._transform.position, target.position) <= this._enemyActionManager.ActionRadius)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
    }
}
