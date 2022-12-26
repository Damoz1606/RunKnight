using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : _APool<EnemyManager>
{
    [SerializeField] private List<PathPoint> _pathPoint = new List<PathPoint>();
    private EnemyType _enemyType;

    public EnemyType EnemyType => _enemyType;

    private void Start()
    {
        this._enemyType = this._objectPrefab.EnemyType;
    }

    public override EnemyManager OnCreate()
    {
        EnemyManager enemy = Instantiate(this._objectPrefab, Vector3.zero, Quaternion.identity);
        enemy.PathPoint = this._pathPoint;
        return enemy;
    }

    public override void OnGet(EnemyManager shape)
    {
        shape.OnActivate();
    }

    public override void OnKill(EnemyManager shape)
    {
        if (this.UsePool)
            this.Pool.Release(shape);
        else
            this.OnRemove(shape);
    }

    public override void OnReleased(EnemyManager shape)
    {
        shape.OnDeactivate();
    }

    public override void OnRemove(EnemyManager shape)
    {
        Destroy(shape);
    }

    public override EnemyManager OnSpawn()
    {
        EnemyManager enemy = null;
        if (this.UsePool)
        {
            enemy = this.Pool.Get();
            enemy.OnActivate();
        }
        else
            enemy = this.OnCreate();
        return enemy;
    }
}
