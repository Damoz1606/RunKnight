using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _pathPoints;
    [SerializeField] private float _waitTime;
    [SerializeField] private float _speed;

    public List<Transform> PathPoints => _pathPoints;
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public float Speed { get => _speed; set => _speed = value; }
}
