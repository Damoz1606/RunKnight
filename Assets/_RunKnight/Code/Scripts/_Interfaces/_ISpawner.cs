using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface _ISpawner<T>
where T : MonoBehaviour
{
    T OnSpawn();
    void OnKill(T shape);
}
