using UnityEngine;

public interface _IState
{
    void OnActivate();
    void OnUpdate();
    void OnDeactivate();
}