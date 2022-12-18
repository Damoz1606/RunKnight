using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : _AAction
{
    public override void Action()
    {
        StartCoroutine(ActionCoroutine());
    }

    public IEnumerator ActionCoroutine()
    {
        Debug.Log("Defend");
        yield return new WaitForSeconds(2f);
        this.OnComplete?.Invoke();
    }
}
