using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _speed;
    [SerializeField] private int _roadCount;
    [SerializeField] private List<RoadPool> dictionaries = new List<RoadPool>();
    [SerializeField] private bool _active = false;
    private Dictionary<RoadType, RoadPool> pools = new Dictionary<RoadType, RoadPool>();
    private List<Road> _roads = new List<Road>();

    private Road _currentRoad;
    public bool ActiveRoad { get => this._active; set => this._active = value; }
    public float SpeedRoad { get => this._speed; set => this._speed = value; }

    private void Awake()
    {
        dictionaries.ForEach(pool => pools.Add(pool.RoadType, pool));
    }

    private void Start()
    {
        this.InitializeRoads();
    }

    private void Update()
    {
        if (this.ActiveRoad)
        {
            this.RoadMotion();
        }
    }

    private void RoadMotion()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * this._speed, Space.World);
        if (this._mainCamera.WorldToScreenPoint(_currentRoad.EndPoint.position).x < 0)
        {
            RoadPool pool;
            pools.TryGetValue(_currentRoad.RoadType, out pool);
            if (pool != null)
            {
                pool.OnKill(_currentRoad);
                this._roads.RemoveAt(0);
                Road auxRoad = pool.OnSpawn();
                auxRoad.transform.position = this._roads[this._roads.Count - 1].EndPoint.position - auxRoad.StartPoint.localPosition;
                this._roads.Add(auxRoad);
                this._currentRoad = this._roads[0];
            }
        }
    }

    private void InitializeRoads()
    {
        Vector3 spawnPosition = this._spawnPoint.position;
        RoadPool pool = this.dictionaries[Random.Range(0, this.dictionaries.Count)];
        for (int road = 0; road < this._roadCount; road++)
        {
            Road auxRoad = pool.OnSpawn();
            spawnPosition -= auxRoad.StartPoint.localPosition;
            auxRoad.transform.position = spawnPosition;
            spawnPosition = auxRoad.EndPoint.position;
            auxRoad.transform.SetParent(this.transform);
            this._roads.Add(auxRoad);
        }
        this._currentRoad = this._roads[0];
    }
}
