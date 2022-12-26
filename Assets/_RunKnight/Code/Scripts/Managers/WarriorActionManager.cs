using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorActionManager : MonoBehaviour
{
    [SerializeField] private float _actionRadius;
    [SerializeField] private float _actionForce;
    [SerializeField] private float _actionCooldownTime;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private bool _inTargetPosition;
    [SerializeField] public bool _action;

    public float ActionRadius => this._actionRadius;
    public float ActionForce => this._actionForce;
    public bool InTargetPosition { get => _inTargetPosition; set => _inTargetPosition = value; }
    public float ActionCooldownTime { get => _actionCooldownTime; set => _actionCooldownTime = value; }
    public LayerMask EnemyLayer => _enemyLayer;
}
