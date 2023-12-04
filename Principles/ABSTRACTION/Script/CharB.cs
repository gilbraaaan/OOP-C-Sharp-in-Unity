using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgilAbstraction;

public class CharB : Character
{

    void Start()
    {
        functionAll = FindObjectOfType<Bridge>();
        functionAll.CharArray.Add(this.gameObject.GetComponent<Character>());
    }

    public override void TryFunction(bool Activate)
    {
        StartCoroutine(Delay(Activate, timeDurationFirst));
    }

    IEnumerator Delay(bool Activated, float First)
    {
        while (Activated)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Attack");
            yield return new WaitForSeconds(First);
        }
        yield return 0;
    }
}
