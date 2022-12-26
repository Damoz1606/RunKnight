using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRemoveEnemy : Node
{
    private Transform _transform;

    public TaskRemoveEnemy(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        GameObject.Destroy(this._transform.gameObject);
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
