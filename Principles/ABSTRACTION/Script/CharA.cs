using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgilAbstraction;

public class CharA : Character
{
    public Rigidbody2D rigid;
    public float jumpForce = 2.5f;

    void Start()
    {
        functionAll = FindObjectOfType<Bridge>();
        functionAll.CharArray.Add(this.gameObject.GetComponent<Character>());
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public override void TryFunction(bool Activate)
    {
        StartCoroutine(Delay(Activate, timeDurationFirst, timeDurationSeconds));
    }

    IEnumerator Delay(bool Activated,float First, float Seconds)
    {
        while (Activated)
        {
            rigid.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            this.gameObject.GetComponent<Animator>().SetBool("Action", true);
            yield return new WaitForSeconds(First);
            this.gameObject.GetComponent<Animator>().SetBool("Action", false);
            yield return new WaitForSeconds(Seconds);
        }
        yield return 0;
    }
}
