using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RunnerManager))]
[RequireComponent(typeof(WarriorActionManager))]
[RequireComponent(typeof(WarriorTargetManager))]
public class DefendAI : BehaviourTree
{
    protected override Node _SetupTree()
    {
        Node root = new Sequence(new List<Node>{
            new Sequence(new List<Node>{
                new Sequence(new List<Node>{
                    new CheckRunEvent(this.transform),
                    new TaskRun(this.transform)
                }),
                new Selector(new List<Node>{
                    new Sequence(new List<Node>{
                        new CheckCharacterOnTarget(this.transform),
                        new CheckMoveToTarget(this.transform),
                        new TaskMoveToTarget(this.transform),
                        new TaskSetCharacterOnTarget(this.transform),
                    }),
                    new Sequence(new List<Node>{
                        new TaskMoveToOrigin(this.transform),
                        new TaskRemoveCharacterOnTarget(this.transform),
                    })
                })
            }),
            new Sequence(new List<Node>{
                new CheckThisCharacterOnTarget(this.transform),
                new Sequence(new List<Node>{
                    new CheckDefendFromEnemyEvent(this.transform),
                    new TaskDefendFromEnemy(this.transform),
                })
            }),
        });

        return root;
    }
}
