using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : State
{
    Transition transition;

    // << Hard..... (다음 Agent 사용하도록 하자)
    Enemy Obj;

    // >>
    bool b = false;

    public override void Awake()
    {
        // << Hard..... (다음 Agent 사용하도록 하자)
        Obj = this.gameObject.GetComponent<Enemy>();
        // >>
        base.Awake();

        transition = gameObject.AddComponent<Transition>();
        transition.condition = gameObject.AddComponent<ToSeek>();
        transitions.Add(transition);
    }

    public override void Update()
    {
        Debug.Log("MOVE-FLEE");

        FleeMove();
    }

    private void FleeMove()
    {
        if (Obj.target)
        {
            if (!b)
            {
                Obj.transform.Rotate(Vector3.up, 180.0f);
                b = true; // 고치자
            }

            Obj.transform.Translate(Vector3.forward * Obj.speedMove * Time.deltaTime);
        }
    }
}
