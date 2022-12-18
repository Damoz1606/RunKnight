using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ObstacleManager _obstacleManager;

    private void Start()
    {
        StartCoroutine(this.SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            _obstacleManager.SpawnObstacle();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void KillSpawnEnemy(FlyEye shape)
    {
        this._obstacleManager.KillObstacle(shape);
    }
}
