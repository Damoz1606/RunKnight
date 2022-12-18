using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _initialSpeed = 5;
    [SerializeField] private float _maxSpeed = 30;
    [SerializeField] private float _incrementSpeed = 1;
    [SerializeField] private float _incrementTime = 1;
    [SerializeField] private float _decrementSpeed = 1;
    [SerializeField] public bool _run = false;
    private bool _hasStopped = true;

    public float Speed => _speed;
    public float IncrementTime => _incrementTime;
    public float InitialSpeed => _initialSpeed;

    public void StartSpeed()
    {
        if (this._hasStopped)
        {
            this._speed = this.InitialSpeed;
            this._hasStopped = false;
        }
    }

    public void StopSpeed()
    {
        this._hasStopped = true;
        this._speed = 0;
    }

    public void IncrementSpeed()
    {
        this._speed += this._incrementSpeed;
        if (this._speed > this._maxSpeed)
            this._speed = this._maxSpeed;
    }

    public void DecrementSpeed()
    {
        this._speed -= this._decrementSpeed;
        if (this._speed < 0)
            this._speed = 0;
    }
}
