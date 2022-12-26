using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _health;

    private void InitHealth()
    {
        this._health = _maxHealth;
    }

    public bool TakeHit(float damage)
    {
        this._health -= damage;
        return this._health <= 0;
    }
}
