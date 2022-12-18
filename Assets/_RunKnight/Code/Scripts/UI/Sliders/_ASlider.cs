using UnityEngine;
using UnityEngine.UI;

public abstract class _ASlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private bool _isSmooth = true;
    [SerializeField] private float _smoothTime = 100;
    private float _currentVelocity = 0;
    private float _slideValue = 0;

    public float SlideValue { get => this._slideValue; set => this._slideValue = value; }

    public abstract void UpdateSlider(float value);

    private void Update()
    {
        this.SmoothSlide();
    }


    private void SmoothSlide()
    {
        float currentValue = 0;
        if (this._isSmooth)
            currentValue = Mathf.SmoothDamp(this._slider.value, _slideValue, ref this._currentVelocity, this._smoothTime * Time.deltaTime);
        else
            currentValue = this._slideValue;
        this._slider.value = currentValue;
    }
}