using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnCompleteIAction();
public interface _IAction
{
    public void OnComplete(OnCompleteIAction action);
}
