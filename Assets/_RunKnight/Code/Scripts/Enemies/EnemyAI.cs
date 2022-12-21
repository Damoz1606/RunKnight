using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(EnemyActionManager))]
public class EnemyAI : BehaviourTree
{
    protected override Node _SetupTree()
    {
        Node root = new Selector(new List<Node>{
            new Sequence(new List<Node>{
                new CheckPlayerTarget(this.transform),
                new Sequence(new List<Node>{
                    new CheckPlayerInAttackArea(this.transform),
                    new TaskAttackPlayer(this.transform)
                })
            }),
            new TaskPatrol(this.transform),
        });

        return root;
    }
}
