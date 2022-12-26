using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorTargetManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private CharacterEvent _type;
    [SerializeField] public bool _isMovingToTarget;
    private Vector3 _origin;

    public Vector3 Target => this._target.position;
    public Vector3 Origin => this._origin;
    public Transform TargetTransform => this._target;

    private void Start()
    {
        this._origin = this.transform.position;
    }

    private void OnEnable()
    {
        EventManager.StartListening(Channel.CHARACTER.ToString(), this._type.ToString(), this.ActiveOnTarget);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Channel.CHARACTER.ToString(), this._type.ToString(), this.ActiveOnTarget);
    }

    private void ActiveOnTarget(object data) => this._isMovingToTarget = !this._isMovingToTarget;
}
