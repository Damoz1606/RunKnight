using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskEnemyRecoil : Node
{
    private Transform _transform;
    private EnemyRecoilManager _recoil;
    private Vector3 _originalPosition;

    public TaskEnemyRecoil(Transform transform)
    {
        _transform = transform;
        this._recoil = this._transform.GetComponent<EnemyRecoilManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._originalPosition.x == 0) this._originalPosition = this._transform.position;
        Vector3 target = this._originalPosition + Vector3.right * this._recoil.ForceTaken;
        if (Vector3.Distance(this._transform.position, target) > 0.01f)
        {
            this._transform.position = Vector3.MoveTowards(this._transform.position, target, this._recoil.ForceTaken * Time.deltaTime);
        }
        else
        {
            this._originalPosition = Vector3.zero;
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
