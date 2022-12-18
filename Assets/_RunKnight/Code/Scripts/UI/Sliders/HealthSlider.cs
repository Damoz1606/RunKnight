using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : _ASlider
{
    public override void UpdateSlider(float value)
    {
        this.SlideValue = value;
    }
}
