using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyRecoil : Node
{
    private Transform _transform;
    private EnemyRecoilManager _recoil;

    public CheckEnemyRecoil(Transform transform)
    {
        _transform = transform;
        this._recoil = this._transform.GetComponent<EnemyRecoilManager>();
    }

    public override NodeState Evaluate()
    {
        if (this._recoil.Recoil)
        {
            this.state = NodeState.SUCCESS;
            return this.state;
        }
        this.state = NodeState.FAILURE;
        return this.state;
    }
}
