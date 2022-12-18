using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 origin;

    public Transform Target { get => target; set => target = value; }

    private void Awake()
    {
        this.origin = this.transform.position;
    }

    public void MoveToTarget()
    {
        if (this.Target != null) this.MoveToTarget(Target.position);
    }

    public void MoveToTarget(Vector3 target)
    {
        this.transform.DOMove(target, 1f)
        .SetEase(Ease.Linear)
        .Play();
    }

    public void MoveToOrigin()
    {
        this.MoveToTarget(this.origin);
    }
}
