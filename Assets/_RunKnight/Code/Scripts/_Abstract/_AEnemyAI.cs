using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class _AEnemyAI : MonoBehaviour
{
    [SerializeField] protected Transform _player;
    [SerializeField] protected float _sightRange = 0;
    [SerializeField] protected float _attackRange = 0;
    [SerializeField] protected LayerMask _whatIsPlayer;
    [SerializeField] protected LayerMask _whatIsGround;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected bool _playerInSightRange;
    [SerializeField] protected bool _playerInAttackRange;
    private void Awake()
    {
        this._player = GameObject.FindGameObjectWithTag("Player").transform;
        this._agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        this._agent.SetDestination(_player.transform.position);
    }

    private void Update()
    {
        /* this._playerInSightRange = Physics.CheckSphere(this.transform.position, this._sightRange, this._whatIsPlayer);
        this._playerInAttackRange = Physics.CheckSphere(this.transform.position, this._attackRange, this._whatIsGround);

        if (!_playerInSightRange && !_playerInAttackRange) this.OnMove();
        if (_playerInSightRange && !_playerInAttackRange) this.OnFollow();
        if (!_playerInSightRange && _playerInAttackRange) this.OnAttack(); */
    }

    protected abstract void OnMove();
    protected abstract void OnFollow();
    protected abstract void OnAttack();
}
