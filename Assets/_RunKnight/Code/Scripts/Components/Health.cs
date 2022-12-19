using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _waitIncreaseTime = 1f;
    [SerializeField] private float _waitDecreaseTime = 1f;
    [SerializeField] private float _incrementValue = 1f;
    [SerializeField] private float _decrementValue = 1f;
    [SerializeField] private float _maxHealth;
    [SerializeField] private _ASlider _ui;
    private float _currentHealth = 0;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    public float HealthPercentage => this.CurrentHealth * 1 / this._maxHealth;

    public float DecrementValue { get => _decrementValue; set => _decrementValue = value; }
    public float IncrementValue { get => _incrementValue; set => _incrementValue = value; }
    public float WaitDecreaseTime { get => _waitDecreaseTime; set => _waitDecreaseTime = value; }
    public float WaitIncreaseTime { get => _waitIncreaseTime; set => _waitIncreaseTime = value; }

    private void Start()
    {
        this.UpdateHealth(this.MaxHealth);
    }

    public void IncrementHealth()
    {
        this.UpdateHealth(this._incrementValue, true);
    }

    public void DecreaseHealth()
    {
        this.UpdateHealth(this._decrementValue, false);
    }

    public void UpdateHealth(float value, bool increase = true)
    {
        this._currentHealth += (increase) ? value : -value;
        if (_currentHealth > this.MaxHealth) this._currentHealth = this.MaxHealth;
        if (_currentHealth < 0) this._currentHealth = 0;
        this._ui.UpdateSlider(this.HealthPercentage);
    }
}
