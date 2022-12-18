using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class _APool<T> : MonoBehaviour
where T : MonoBehaviour, _IPoolObject
{
    [SerializeField] protected T _objectPrefab;
    [SerializeField] protected bool _usePool = true;
    [SerializeField] protected int _defaultCapacity = 10;
    [SerializeField] protected int _maxCapacity = 10;

    protected ObjectPool<T> _pool;

    public virtual bool UsePool { set => this._usePool = value; get => this._usePool; }
    protected ObjectPool<T> Pool
    {
        get
        {
            if (this._pool == null)
                this._pool = new ObjectPool<T>(OnCreate, OnGet, OnReleased, OnKill, false, this._defaultCapacity, this._maxCapacity);
            return this._pool;
        }
    }

    public abstract T OnCreate();
    public abstract void OnGet(T shape);
    public abstract void OnKill(T shape);
    public abstract void OnReleased(T shape);
    public abstract void OnRemove(T shape);
    public abstract T OnSpawn();
}
