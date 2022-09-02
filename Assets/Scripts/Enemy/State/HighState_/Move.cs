using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : StateHighLevel
{
    // HFSM
    Transition transition1;
    Transition transition2;

    public override void Awake()
    {
        // HFSM
        transition1 = new Transition();
        transition1.condition = new ToIdle();
        transitions.Add(transition1);

        transition2 = new Transition();
        transition2.condition = new ToAttack();
        transitions.Add(transition2);

        // FSM
        State sSeek = this.gameObject.AddComponent<Seek>();
        sSeek.enabled = false;
        states.Add(sSeek);

        State sFlee = this.gameObject.AddComponent<Flee>();
        sFlee.enabled = false;
        states.Add(sFlee);

        sSeek.transitions[0].target = sFlee;
        sFlee.transitions[0].target = sSeek;
    }
}
