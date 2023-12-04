using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgilPolymorphism;

public class A : Action
{
    bool rotate = false;
    public float RotateSpeed = -600f;
    public Transform weapon;

    void Start() {
        functionAll = FindObjectOfType<StartFunction>();
        functionAll.actionFinding.Add(this.gameObject.GetComponent<Action>());
    }

    public override void StartAction()
    {
        base.StartAction();
        rotate = true;
        weapon.transform.gameObject.SetActive(true);
        this.gameObject.GetComponent<Animator>().SetBool("Action", true);
    }

    void Update()
    {
        if(rotate == true)
        {
            weapon.transform.Rotate(transform.rotation.x, 
                transform.rotation.y, 
                Time.deltaTime * RotateSpeed);
        }
    }

    public override void EndAction()
    {
        base.EndAction();
        rotate = false;
        this.gameObject.GetComponent<Animator>().SetBool("Action", false);
        weapon.transform.localRotation = Quaternion.Euler(transform.rotation.x,
            transform.rotation.y,
            44f);
        weapon.transform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        functionAll.actionFinding.Remove(this.gameObject.GetComponent<Action>());
    }
}
