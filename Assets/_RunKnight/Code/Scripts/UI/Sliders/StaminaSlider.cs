using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSlider : _ASlider
{
    public override void UpdateSlider(float value)
    {
        this.SlideValue = value;
    }
}
