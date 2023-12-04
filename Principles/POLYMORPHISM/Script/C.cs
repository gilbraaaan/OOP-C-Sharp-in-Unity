using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgilPolymorphism;

public class C : Action
{
    bool movement = false;
    public float firstPositionX, Distance = 0.2f, speed = 1f;
    void Start()
    {
        firstPositionX = transform.position.x;
        functionAll = FindObjectOfType<StartFunction>();
        functionAll.actionFinding.Add(this.gameObject.GetComponent<Action>());
    }

    public override void StartAction()
    {
        movement = true;
        this.gameObject.GetComponent<Animator>().SetBool("Action", true);
    }

    void FixedUpdate()
    {
        if(movement == true)
        {
            transform.position = new Vector3(
                transform.position.x + Mathf.PingPong(Time.time * speed, Distance) - Distance / 2f,
                transform.position.y,
                transform.position.z);
        }
    }

    public override void EndAction()
    {
        base.EndAction();
        movement = false;
        this.gameObject.GetComponent<Animator>().SetBool("Action", false);
        transform.position = new Vector3(
            firstPositionX,
            transform.position.y,
            transform.position.z);
    }

    private void OnDestroy()
    {
        functionAll.actionFinding.Remove(this.gameObject.GetComponent<Action>());
    }
}
