using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTo))]
public class FlyEye : _AEnemy
{
    private MoveTo _moveTo;
    [SerializeField] private EventRadius _attackRadius;
    [SerializeField] private EventRadius _damageRadius;

    private void Awake()
    {
        this._moveTo = this.GetComponent<MoveTo>();
    }

    public override void OnActivate()
    {
        this._animator.SetBool("Attack", false);
        this._animator.SetBool("Death", false);
        this.ActivateTarget();
        this._attackRadius.TriggerEnter += this.OnTriggerAttack;
        this._damageRadius.TriggerEnter += this.OnTriggerDamage;
    }

    private void ActivateTarget()
    {
        this._moveTo.Target = this._target;
        this._moveTo.MoveToTarget();
    }

    public override void OnDeactivate()
    {
        this._attackRadius.TriggerEnter -= this.OnTriggerAttack;
        this._damageRadius.TriggerEnter -= this.OnTriggerDamage;
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerAttack(Collider other)
    {
        if (other.CompareTag(this._player.tag))
        {
            StartCoroutine(this.AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        this._animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1);
        this._animator.SetBool("Attack", false);
    }

    private void OnTriggerDamage(Collider other)
    {
        if (other.CompareTag("Attacker"))
        {
            StartCoroutine(this.DamageCoroutine());
        }
    }

    private IEnumerator DamageCoroutine()
    {
        this._animator.SetBool("Death", true);
        yield return new WaitForSeconds(1);
        //Remove character
    }
}
