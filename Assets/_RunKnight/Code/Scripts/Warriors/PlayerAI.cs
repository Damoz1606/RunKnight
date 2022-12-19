using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(RunnerManager))]
public class PlayerAI : BehaviourTree
{
    [SerializeField] private EndlessRoad _road;
    private PlayerManager _playerManager;

    public PlayerManager PlayerManager { get => _playerManager; set => _playerManager = value; }

    protected override void Start()
    {
        base.Start();
        this._playerManager = this.GetComponent<PlayerManager>();
    }

    protected override Node _SetupTree()
    {
        Node root = new Selector(new List<Node>{
            new Sequence(new List<Node>{
                new CheckRunEvent(this.transform),
                new TaskRun(this.transform),
                new TaskLetWarriorsRun(this.transform),
                new TaskMoveRoadActivate(this.transform, this._road),
                new TaskRunningStaminaDecrease(this.transform)
            }),
            new Sequence(new List<Node>{
                new TaskLetWarriorsStop(this.transform),
                new TaskMoveRoadDeactivate(this.transform, this._road),
                new CheckGameStarted(this.transform),
                new TaskNoRunningHealthDecrease(this.transform),
                new TaskNoRunningStaminaIncrement(this.transform)
            })
        });

        return root;
    }
}
