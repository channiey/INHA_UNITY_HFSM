using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRecovery : Condition
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
        if (Obj.Health <= Obj.HealthMax * 0.5f)
            return true;
        else
            return false;
    }
}


