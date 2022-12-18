using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _AEnemy : MonoBehaviour, _IPoolObject
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Transform _target;
    [SerializeField] protected GameObject _player;

    public Transform Target { get => _target; set => _target = value; }

    public abstract void OnActivate();
    public abstract void OnDeactivate();
    public abstract void OnUpdate();
}
