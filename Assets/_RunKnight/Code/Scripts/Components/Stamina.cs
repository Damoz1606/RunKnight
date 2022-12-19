using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float _waitIncreaseTime = 1f;
    [SerializeField] private float _waitDecreaseTime = 1f;
    [SerializeField] private float _incrementValue = 1f;
    [SerializeField] private float _decrementValue = 1f;
    [SerializeField] private float _maxStamina;
    [SerializeField] private _ASlider _ui;
    private float _currentStamina = 0;

    public float MaxStamina { get => _maxStamina; set => _maxStamina = value; }
    public float CurrentStamina { get => _currentStamina; set => _currentStamina = value; }
    public float StaminaPercentaje => this.CurrentStamina * 1 / this.MaxStamina;

    public float DecrementValue { get => _decrementValue; set => _decrementValue = value; }
    public float IncrementValue { get => _incrementValue; set => _incrementValue = value; }
    public float WaitDecreaseTime { get => _waitDecreaseTime; set => _waitDecreaseTime = value; }
    public float WaitIncreaseTime { get => _waitIncreaseTime; set => _waitIncreaseTime = value; }

    private void Start()
    {
        this.UpdateStamina(this.MaxStamina);
    }

    public void IncreaseStamina()
    {
        this.UpdateStamina(this._incrementValue, true);
    }

    public void DecreaseStamina()
    {
        this.UpdateStamina(this._decrementValue, false);
    }

    public void UpdateStamina(float value, bool increase = true)
    {
        this._currentStamina += (increase) ? value : -value;
        if (this._currentStamina > this._maxStamina) this._currentStamina = this._maxStamina;
        if (this._currentStamina < 0) this._currentStamina = 0;
        this._ui.UpdateSlider(this.StaminaPercentaje);
    }
}
