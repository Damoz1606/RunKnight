using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRadius : MonoBehaviour
{
    public UnityAction<Collider> TriggerEnter;
    public UnityAction<Collider> TriggerExit;
    public UnityAction<Collision> CollisionEnter;
    public UnityAction<Collision> CollisionExit;

    private void OnTriggerEnter(Collider other)
    {
        this.TriggerEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        this.TriggerExit?.Invoke(other);
    }

    private void OnCollisionExit(Collision other)
    {
        this.CollisionExit?.Invoke(other);
    }

    private void OnCollisionEnter(Collision other)
    {
        this.CollisionEnter?.Invoke(other);
    }
}
