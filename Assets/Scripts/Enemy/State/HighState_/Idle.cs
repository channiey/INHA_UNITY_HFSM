using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateHighLevel
{
    // HFSM
    Transition transition1;
    Transition transition2;

    public override void Awake()
    {
        // HFSM
        transition1 = new Transition();
        transition1.condition = new ToMove();
        transitions.Add(transition1);

        transition2 = new Transition();
        transition2.condition = new ToAttack();
        transitions.Add(transition2);

        // FSM
        State sRecovery = this.gameObject.AddComponent<Recovery>();
        sRecovery.enabled = false;
        states.Add(sRecovery);

        State sPatrol = this.gameObject.AddComponent<Patrol>();
        sPatrol.enabled = false;
        states.Add(sPatrol);

        sRecovery.transitions[0].target = sPatrol;
        sPatrol.transitions[0].target = sPatrol;

        states[0].enabled = true;
    }
    
}
