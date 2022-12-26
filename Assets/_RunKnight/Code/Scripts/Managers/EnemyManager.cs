using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(EnemyActionManager))]
[RequireComponent(typeof(EnemyHealthManager))]
[RequireComponent(typeof(EnemyRecoilManager))]
[RequireComponent(typeof(EnemyAI))]
public class EnemyManager : MonoBehaviour, _IPoolObject
{
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private List<PathPoint> _pathPoint = new List<PathPoint>();
    private Patrol _patrol;
    private EnemyActionManager _action;
    private EnemyHealthManager _health;
    private EnemyRecoilManager _recoil;
    private EnemyAI _ai;

    public EnemyType EnemyType => _enemyType;
    public List<PathPoint> PathPoint { get => _pathPoint; set => _pathPoint = value; }

    private void Awake()
    {
        _patrol = this.GetComponent<Patrol>();
        _action = this.GetComponent<EnemyActionManager>();
        _health = this.GetComponent<EnemyHealthManager>();
        _recoil = this.GetComponent<EnemyRecoilManager>();
        _ai = this.GetComponent<EnemyAI>();
    }

    public void OnActivate()
    {
        int patrolIndex = Random.Range(0, this.PathPoint.Count);
        this._patrol.PathPoints = this.PathPoint[patrolIndex].points;
        this.transform.position = this._patrol.PathPoints[0].position;
        this._health.InitHealth();
        this.gameObject.SetActive(true);
    }

    public void OnDeactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
