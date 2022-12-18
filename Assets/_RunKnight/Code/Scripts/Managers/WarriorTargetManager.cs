using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorTargetManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] public bool _isMovingToTarget;
    private Vector3 _origin;

    private void Start()
    {
        this._origin = this.transform.position;
    }

    public Vector3 Target => this._target.position;
    public Vector3 Origin => this._origin;

    public Transform TargetTransform => this._target;
}
