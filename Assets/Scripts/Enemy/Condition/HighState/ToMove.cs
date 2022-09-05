using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMove : Condition
{
    // << Hard..... (다음 Agent 사용하도록 하자)
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
