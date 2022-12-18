using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : _APool<Road>
{
    private RoadType _type;

    public RoadType RoadType => this._type;

    private void Awake()
    {
        this._type = this._objectPrefab.RoadType;
    }

    public override Road OnCreate()
    {
        return Instantiate(this._objectPrefab, Vector3.zero, Quaternion.identity);
    }

    public override void OnGet(Road shape)
    {
        shape.OnActivate();
    }

    public override void OnKill(Road shape)
    {
        if (this.UsePool)
            this.Pool.Release(shape);
        else
            this.OnKill(shape);
    }

    public override void OnReleased(Road shape)
    {
        shape.OnDeactivate();
    }

    public override void OnRemove(Road shape)
    {
        Destroy(shape);
    }

    public override Road OnSpawn()
    {
        return (this.UsePool) ? this.Pool.Get() : this.OnCreate();
    }
}
