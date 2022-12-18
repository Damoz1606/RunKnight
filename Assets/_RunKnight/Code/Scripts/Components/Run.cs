using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float _speed;

    public float Speed
    {
        get => _speed;
        set
        {
            _speed = value;
            this.animator.speed = value;
        }
    }

    public void Activate(bool isRunning)
    {
        // this.animator.SetInteger("AirSpeedY", 0);
        if (isRunning)
        {
            this.animator.SetBool("Grounded", true);
            this.animator.SetInteger("AnimState", 1);
        }
        else
        {
            this.animator.SetBool("Grounded", true);
            this.animator.SetInteger("AnimState", 0);
        }
    }
}
