using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMove : Condition
{
    // << Hard..... (���� Agent ����ϵ��� ����)
    Enemy Obj = null;
    // >>

   


    public override bool Test()
    {
        //return false;

        if (Obj.target != null)
            return true;
        else
            return false;

        //return false;

    }
}
