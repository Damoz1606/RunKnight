using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerTarget : Node
{
    private Transform _transform;
    private EnemyActionManager _action;
    private Animator _animator;

    public CheckPlayerTarget(Transform transform)
    {
        _transform = transform;
        this._action = this._transform.GetComponent<EnemyActionManager>();
        this._animator = this._transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object target = this.GetData("target-player");
        if (target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, this._action.ActionRadius, this._action.EnemyLayer);
            if (colliders.Length > 0)
            {
                this.Parent.Parent.SetData("target-player", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }
            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
