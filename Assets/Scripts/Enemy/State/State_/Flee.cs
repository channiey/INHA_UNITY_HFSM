using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : State
{
    Transition transition;

    // << Hard..... (���� Agent ����ϵ��� ����)
    Enemy Obj;

    // >>
    bool b = false;

    public override void Awake()
    {
        // << Hard..... (���� Agent ����ϵ��� ����)
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
                b = true; // ��ġ��
            }

            Obj.transform.Translate(Vector3.forward * Obj.speedMove * Time.deltaTime);
        }
    }
}
