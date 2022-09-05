using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : State
{
    Transition transition;

    // << Hard..... (다음 Agent 사용하도록 하자)
    Enemy Obj;
    // >>

    public override void Awake()
    {
        base.Awake();

        transition = gameObject.AddComponent<Transition>();
        transition.condition = gameObject.AddComponent<ToPatrol>();
        transitions.Add(transition);

        // << Hard..... (다음 Agent 사용하도록 하자)
        Obj = this.gameObject.GetComponent<Enemy>();
        // >>
    }

    public override void Update()
    {
        Debug.Log("IDLE-RECOVERY!");

        RecoveryHP();


    }

    void RecoveryHP()
    {
        Obj.Health += Obj.recoveryHP;

        if (Obj.Health >= Obj.HealthMax)
            Obj.Health = Obj.HealthMax;
    }
}
