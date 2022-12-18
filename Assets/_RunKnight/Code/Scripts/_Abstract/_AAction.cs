using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public abstract class _AAction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private UnityAction _onComplete;
    protected Vector3 origin;

    public UnityAction OnComplete { get => _onComplete; set => _onComplete = value; }

    private void Awake()
    {
        this.origin = this.gameObject.transform.position;
    }
    
    public abstract void Action();

    protected void RestoreRunning()
    {
        Manager.EventManager.TriggerEvent(Channel.CHARACTER.ToString(), CharacterEvent.RUN.ToString(), true);
    }
}
