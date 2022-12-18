using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionManager : MonoBehaviour
{
    [SerializeField] private Transform _warriorOnTarget;

    public Transform WarriorOnTarget { get => _warriorOnTarget; set => _warriorOnTarget = value; }
}
