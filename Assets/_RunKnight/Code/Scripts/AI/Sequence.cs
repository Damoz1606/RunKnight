using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public Sequence()
    {
    }

    public Sequence(List<Node> children) : base(children)
    {
    }

    public override NodeState Evaluate()
    {
        bool isAnyChildRunning = false;
        foreach (Node node in this.children)
        {
            switch (node.Evaluate())
            {
                case NodeState.FAILURE:
                    this.state = NodeState.FAILURE;
                    return this.state;
                case NodeState.SUCCESS:
                    continue;
                case NodeState.RUNNING:
                    isAnyChildRunning = true;
                    continue;
                default:
                    this.state = NodeState.SUCCESS;
                    return this.state;
            }
        }
        this.state = (isAnyChildRunning) ? NodeState.RUNNING : NodeState.SUCCESS;
        return this.state;
    }
}
