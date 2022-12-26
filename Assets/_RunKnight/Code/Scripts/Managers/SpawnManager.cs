using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnTime = 0;
    [SerializeField] private List<KeyValue<EnemyType, EnemyPool>> _pools = new List<KeyValue<EnemyType, EnemyPool>>();
    private Dictionary<EnemyType, EnemyPool> _spawnDictionary = new Dictionary<EnemyType, EnemyPool>();

    private void Awake()
    {
        _pools.ForEach(value => this._spawnDictionary.Add(value.key, value.value));
    }

    private void Start()
    {
        StartCoroutine(this.SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (!Manager.GameManager.IsGameOver)
        {
            this.Spawn();
            yield return new WaitForSeconds(this.spawnTime);
        }
        yield break;
    }

    public void Spawn()
    {
        int index = Random.Range(0, _spawnDictionary.Count);
        EnemyType enemyType = this.GetPoolType(index);
        EnemyPool pool = null;
        if (this._spawnDictionary.TryGetValue(enemyType, out pool))
        {
            EnemyManager enemy = pool.OnSpawn();
        }
    }

    private EnemyType GetPoolType(int index)
    {
        switch (index)
        {
            case 0:
                return EnemyType.FLY_EYE;
            case 1:
                return EnemyType.TEST;
            default:
                return EnemyType.FLY_EYE;
        }
    }

    public void Kill(EnemyManager enemy)
    {
        EnemyPool pool = null;
        if (this._spawnDictionary.TryGetValue(enemy.EnemyType, out pool))
        {
            pool.OnKill(enemy);
        }
        else
        {
            Destroy(enemy);
        }
    }
}
