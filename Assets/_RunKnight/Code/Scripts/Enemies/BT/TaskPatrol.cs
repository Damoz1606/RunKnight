using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Patrol _patrol;

    private int _currentIndex = 0;
    private bool _isWaiting = false;
    private float _counter;

    public TaskPatrol(Transform transform)
    {
        _transform = transform;
        this._patrol = this._transform.GetComponent<Patrol>();
    }

    public override NodeState Evaluate()
    {
        if (this._isWaiting)
        {
            this._counter += Time.deltaTime;
            if (this._counter >= this._patrol.WaitTime)
                this._isWaiting = false;
        }
        else
        {
            Transform _point = this._patrol.PathPoints[this._currentIndex];
            if (Vector3.Distance(this._transform.position, _point.position) < 0.01f)
            {
                this._counter = 0;
                this._isWaiting = true;
                this._currentIndex = (this._currentIndex + 1) % this._patrol.PathPoints.Count;
            }
            else
            {
                this._transform.position = Vector3.MoveTowards(this._transform.position, _point.position, this._patrol.Speed * Time.deltaTime);
            }
        }
        this.state = NodeState.RUNNING;
        return this.state;
    }
}
