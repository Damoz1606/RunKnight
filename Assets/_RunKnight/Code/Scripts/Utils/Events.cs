using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Channel
{
    TARGET,
    CHARACTER,
    UI
}

enum CharacterEvent
{
    IDLE,
    RUN,
    JUMP,
    ATTACK,
    DEFENSE
}

enum TargetEvent {
    MOVE_TO_TARGET
}

enum UIEvent
{
    HEALTH,
    STAMINA
}
