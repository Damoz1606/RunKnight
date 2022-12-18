using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour, _IPoolObject
{
    [SerializeField] private Transform _startRoad;
    [SerializeField] private Transform _endRoad;
    [SerializeField] private RoadType _type;

    public Transform StartPoint => this._startRoad;
    public Transform EndPoint => this._endRoad;
    public RoadType RoadType => this._type;

    public void OnActivate()
    {
        this.gameObject.SetActive(true);
    }

    public void OnDeactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void OnUpdate()
    {

    }
}
