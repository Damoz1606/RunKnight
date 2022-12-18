using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float _maxScore;
    [SerializeField] private float _increseValue = 1;
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private float _speed = 0;
    private float _currentScore = 0;

    public float CurrentScore => _currentScore;
    public float MaxScore { get => _maxScore; set => _maxScore = value; }
    public float Speed { get => _speed; set => _speed = value; }

    void Start()
    {
        this.UpdateScore(0);
    }

    public void OnUpdate()
    {
        this.UpdateScore(this._increseValue * this.Speed);
    }

    public void UpdateScore(float value)
    {
        this._currentScore += value;
        this._scoreUI.UpdateUI(this._currentScore);
    }
}
