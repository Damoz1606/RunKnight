using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _health;

    public void InitHealth()
    {
        this._health = _maxHealth;
    }

    public bool TakeHit(float damage)
    {
        this._health -= damage;
        if (this._health <= 0)
        {
            Manager.SpawnManager.Kill(this.GetComponent<EnemyManager>());
            Manager.ScoreManager.UpdateScore(this._health);
        }
        return this._health <= 0;
    }
}
