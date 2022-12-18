using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private _ASlider _ui;
    private float _currentHealth = 0;

    public UnityAction OnDeath;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    public float HealthPercentage => this.CurrentHealth * 1 / this._maxHealth;

    private void Start()
    {
        this.UpdateHealth(this.MaxHealth);
    }

    public void UpdateHealth(float value, bool increase = true)
    {
        this._currentHealth += (increase) ? value : -value;
        if (_currentHealth > this.MaxHealth) this._currentHealth = this.MaxHealth;
        if (_currentHealth < 0) this._currentHealth = 0;
        this._ui.UpdateSlider(this.HealthPercentage);
        if (this._currentHealth <= 0) this.OnDeath?.Invoke();
    }
}
