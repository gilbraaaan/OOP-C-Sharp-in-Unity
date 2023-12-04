using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgilPolymorphism;

public class B : Action
{
    bool Jump = false;
    public Rigidbody2D rigid;
    public float jumpForce = 2.5f;

    void Start()
    {
        functionAll = FindObjectOfType<StartFunction>();
        functionAll.actionFinding.Add(this.gameObject.GetComponent<Action>());
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }
    public override void StartAction()
    {
        base.StartAction();
        Jump = true;
        StartCoroutine(Delay());
    }

    public override void EndAction()
    {
        base.EndAction();
        Jump = false;
    }

    IEnumerator Delay()
    {
        while (Jump)
        {
            rigid.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            this.gameObject.GetComponent<Animator>().SetBool("Action", true);
            yield return new WaitForSeconds(.8f);
            this.gameObject.GetComponent<Animator>().SetBool("Action", false);
            yield return new WaitForSeconds(.2f);
        }
        yield return 0;
    }

    private void OnDestroy()
    {
        functionAll.actionFinding.Remove(this.gameObject.GetComponent<Action>());
    }
}
