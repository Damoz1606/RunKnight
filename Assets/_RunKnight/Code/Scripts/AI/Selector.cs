using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector()
    {
    }

    public Selector(List<Node> children) : base(children)
    {
    }

    public override NodeState Evaluate()
    {
        foreach (Node node in this.children)
        {
            switch (node.Evaluate())
            {
                case NodeState.FAILURE:
                    continue;
                case NodeState.SUCCESS:
                    this.state = NodeState.SUCCESS;
                    return this.state;
                case NodeState.RUNNING:
                    this.state = NodeState.RUNNING;
                    return this.state;
                default:
                    continue;
            }
        }
        this.state = NodeState.FAILURE;
        return this.state;
    }
}
