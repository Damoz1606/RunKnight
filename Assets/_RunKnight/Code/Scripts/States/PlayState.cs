using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour, _IState
{
    public void OnActivate()
    {
        Manager.GameManager.HasStarted = true;
    }

    public void OnDeactivate()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        if (!Manager.GameManager.IsGameOver && Manager.GameManager.HasStarted)
        {
            Manager.ScoreManager.OnUpdate();
        }
    }
}
