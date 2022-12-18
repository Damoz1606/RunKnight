using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyePool : _APool<FlyEye>
{
    [SerializeField] private Transform _target;
    public override FlyEye OnCreate()
    {
        FlyEye flyEye = Instantiate(this._objectPrefab, this.transform.position, Quaternion.identity);
        flyEye.Target = this._target;
        flyEye.OnActivate();
        return flyEye;
    }

    public override void OnGet(FlyEye shape)
    {
        shape.transform.position = this.transform.position;
        shape.OnActivate();
    }

    public override void OnKill(FlyEye shape)
    {
        if (this.UsePool)
            this.Pool.Release(shape);
        else
            this.OnKill(shape);
    }

    public override void OnReleased(FlyEye shape)
    {
        shape.OnDeactivate();
    }

    public override void OnRemove(FlyEye shape)
    {
        Destroy(shape);
    }

    public override FlyEye OnSpawn()
    {
        return (this.UsePool) ? this.Pool.Get() : this.OnCreate();
    }
}
