using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float _maxStamina;
    [SerializeField] private _ASlider _ui;
    private float _currentStamina = 0;

    public UnityAction OutStamina;

    public float MaxStamina { get => _maxStamina; set => _maxStamina = value; }
    public float CurrentStamina { get => _currentStamina; set => _currentStamina = value; }
    public float StaminaPercentaje => this.CurrentStamina * 1 / this.MaxStamina;

    private void Start()
    {
        this.UpdateStamina(this.MaxStamina);
    }

    public void UpdateStamina(float value, bool increase = true)
    {
        this._currentStamina += (increase) ? value : -value;
        if (this._currentStamina > this._maxStamina) this._currentStamina = this._maxStamina;
        if (this._currentStamina < 0) this._currentStamina = 0;
        this._ui.UpdateSlider(this.StaminaPercentaje);
        if (this._currentStamina <= 0) this.OutStamina?.Invoke();
    }
}
