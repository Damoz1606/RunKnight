using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : _AAction
{

    public override void Action()
    {
        StartCoroutine(ActionCoroutine());
    }

    public IEnumerator ActionCoroutine()
    {
        Debug.Log("Attack");
        yield return new WaitForSeconds(2f);
        this.OnComplete?.Invoke();
    }


}
