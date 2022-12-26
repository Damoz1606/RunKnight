using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private WarriorActionManager _attack;
    [SerializeField] private WarriorActionManager _defend;
    [SerializeField] private float _scoreIncrease;

    public WarriorActionManager Defend { get => _defend; set => _defend = value; }
    public WarriorActionManager Attack { get => _attack; set => _attack = value; }
    public float ScoreIncrease { get => _scoreIncrease; set => _scoreIncrease = value; }
}
