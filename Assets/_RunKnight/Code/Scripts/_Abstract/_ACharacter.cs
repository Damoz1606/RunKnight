using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Run))]
public abstract class _ACharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _startSpeed = 5;
    [SerializeField] private float _maxSpeed = 30;
    protected Run _run;

    public float StartSpeed { get => _startSpeed; set => _startSpeed = value; }
    public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }
    public virtual float Speed
    {
        get => _speed; set
        {
            _speed = value;
            if (this._speed > this._maxSpeed) this._speed = this._maxSpeed;
        }
    }

    protected virtual void Awake()
    {
        this._run = this.GetComponent<Run>();
    }

    protected virtual void OnEnable()
    {
        EventManager.StartListening(Channel.CHARACTER.ToString(), CharacterEvent.RUN.ToString(), this.RunTrigger);
    }

    protected virtual void OnDisable()
    {
        EventManager.StopListening(Channel.CHARACTER.ToString(), CharacterEvent.RUN.ToString(), this.RunTrigger);
    }

    protected abstract void RunTrigger(object message);
}
