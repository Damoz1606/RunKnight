using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(EventManager))]
[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(StateManager))]
public class Manager : MonoBehaviour
{
    private static AudioManager _audioManager;
    private static EventManager _eventManager;
    private static GameManager _gameManager;
    private static ScoreManager _scoreManager;
    private static StateManager _stateManager;

    public static AudioManager AudioManager
    {
        get
        {
            if (_audioManager == null)
                _audioManager = FindObjectOfType<AudioManager>();
            return _audioManager;
        }
    }
    public static EventManager EventManager
    {
        get
        {
            if (_eventManager == null)
                _eventManager = FindObjectOfType<EventManager>();
            return _eventManager;
        }
    }
    public static GameManager GameManager
    {
        get
        {
            if (_gameManager == null)
                _gameManager = FindObjectOfType<GameManager>();
            return _gameManager;
        }
    }
    public static ScoreManager ScoreManager
    {
        get
        {
            if (_scoreManager == null)
                _scoreManager = FindObjectOfType<ScoreManager>();
            return _scoreManager;
        }
    }
    public static StateManager StateManager
    {
        get
        {
            if (_stateManager == null)
                _stateManager = FindObjectOfType<StateManager>();
            return _stateManager;
        }
    }

    private void Awake()
    {
        _audioManager = GetComponent<AudioManager>();
        _eventManager = GetComponent<EventManager>();
        _gameManager = GetComponent<GameManager>();
        _scoreManager = GetComponent<ScoreManager>();
        _stateManager = GetComponent<StateManager>();
    }
}
