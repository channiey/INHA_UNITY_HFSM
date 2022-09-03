using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : State
{
    Transition transition;

    // << Hard..... (다음 Agent 사용하도록 하자)
    Enemy Obj;
    // >>

    public override void Awake()
    {

        base.Awake();

        transition = new Transition();
        transition.condition = new ToFlee();
        transitions.Add(transition);

        // << Hard..... (다음 Agent 사용하도록 하자)
        Obj = this.gameObject.GetComponent<Enemy>();
        // >>
    }

    public override void Update()
    {
        Debug.Log("추격중!");

        Vector3 dir = Obj.transform.position - Obj.target.transform.position;

        Obj.transform.Translate(dir.normalized * Obj.speedMove * Time.deltaTime);
    }

}
