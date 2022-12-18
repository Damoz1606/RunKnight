using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    public void UpdateUI(float value)
    {
        this._score.text = $"{value.ToString("0")}";
    }
}
