using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class Node
{
    private Node parent;
    protected NodeState state;
    protected List<Node> children = new List<Node>();
    private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

    public Node Parent => parent;

    public Node()
    {
        this.parent = null;
    }

    public Node(List<Node> children)
    {
        foreach (Node node in children)
            _Attach(node);
    }

    private void _Attach(Node node)
    {
        node.parent = this;
        this.children.Add(node);
    }

    public void SetData(string key, object data)
    {
        this._dataContext.Add(key, data);
    }

    public object GetData(string key)
    {
        object data = null;
        if (this._dataContext.TryGetValue(key, out data))
            return data;
        Node node = this.Parent;
        while (node != null)
        {
            data = node.GetData(key);
            if (data != null)
                return data;
            node = node.Parent;
        }
        return null;
    }

    public bool ClearData(string key)
    {
        if (this._dataContext.ContainsKey(key))
        {
            this._dataContext.Remove(key);
            return true;
        }
        Node node = this.Parent;
        while (node != null)
        {
            bool cleared = node.ClearData(key);
            if (cleared)
                return true;
            node = node.Parent;
        }
        return false;
    }

    public virtual NodeState Evaluate() => NodeState.FAILURE;


}
