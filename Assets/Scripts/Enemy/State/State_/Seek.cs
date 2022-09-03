using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : State
{
    Transition transition;

    // << Hard..... (���� Agent ����ϵ��� ����)
    Enemy Obj;
    // >>

    public override void Awake()
    {

        base.Awake();

        transition = new Transition();
        transition.condition = new ToFlee();
        transitions.Add(transition);

        // << Hard..... (���� Agent ����ϵ��� ����)
        Obj = this.gameObject.GetComponent<Enemy>();
        // >>
    }

    public override void Update()
    {
        Debug.Log("�߰���!");

        Vector3 dir = Obj.transform.position - Obj.target.transform.position;

        Obj.transform.Translate(dir.normalized * Obj.speedMove * Time.deltaTime);
    }

}
