using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PathPoint
{
    [SerializeField] public List<Transform> points;
}