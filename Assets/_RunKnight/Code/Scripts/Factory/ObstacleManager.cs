using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private FlyEyePool _pool;

    public void SpawnObstacle()
    {
        _pool.OnSpawn();
    }

    public void KillObstacle(FlyEye shape)
    {
        _pool.OnKill(shape);
    }
}
