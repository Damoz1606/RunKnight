using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourTree : MonoBehaviour
{
    private Node _root = null;
    protected virtual void Start()
    {
        this._root = this._SetupTree();
    }

    protected virtual void Update()
    {
        if (this._root != null) this._root.Evaluate();
    }

    protected abstract Node _SetupTree();
}
