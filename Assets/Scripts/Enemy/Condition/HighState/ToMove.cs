using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMove : Condition
{
    // << Hard..... (���� Agent ����ϵ��� ����)
    [SerializeField] Enemy Obj = null;
    // >>

    private void Awake()
    {
        Obj = this.gameObject.GetComponent<Enemy>();
    }


    public override bool Test()
    {
        if (Obj.target)
            return true;
        else
            return false;

        //return false;

    }
}
