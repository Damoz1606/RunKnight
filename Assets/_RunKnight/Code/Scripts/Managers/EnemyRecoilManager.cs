using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecoilManager : MonoBehaviour
{
    [SerializeField] private bool _recoil;
    private float _forceTaken = 0;

    public float ForceTaken => _forceTaken;
    public bool Recoil { get => _recoil; set => _recoil = value; }

    public void TakeForceAndProtectSelf(float force)
    {
        StartCoroutine(this.TakeForceAndProtectSelfCoroutine(force));
    }

    private IEnumerator TakeForceAndProtectSelfCoroutine(float force)
    {
        this.Recoil = true;
        this._forceTaken = force;
        yield return new WaitForSeconds(1);
        this.Recoil = false;
        this._forceTaken = 0;
        yield break;
    }
}
