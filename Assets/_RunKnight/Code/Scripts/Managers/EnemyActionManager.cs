using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionManager : MonoBehaviour
{
    [SerializeField] private float _actionRadius;
    [SerializeField] private float _actionForce;
    [SerializeField] private float _actionCooldownTime;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private bool _inTargetPosition;
    [SerializeField] private bool _done = false;

    public bool InTargetPosition { get => _inTargetPosition; set => _inTargetPosition = value; }
    public LayerMask EnemyLayer { get => _enemyLayer; set => _enemyLayer = value; }
    public float ActionCooldownTime { get => _actionCooldownTime; set => _actionCooldownTime = value; }
    public float ActionForce { get => _actionForce; set => _actionForce = value; }
    public float ActionRadius { get => _actionRadius; set => _actionRadius = value; }
    public bool Done { get => _done; set => _done = value; }

    public void DoneAction()
    {
        this._done = true;
    }
}
