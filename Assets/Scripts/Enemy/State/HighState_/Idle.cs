using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateHighLevel
{
    // HFSM - (Transitions)
    [SerializeField] Transition transition1;
    [SerializeField] Transition transition2;

    public override void Awake()
    {
        base.Awake();


        // HFSM - (Transitions)
        transition1 = gameObject.AddComponent<Transition>();
        /*
            Monobehaviour를 상속받은 클래스는 new 키워드로 생성이 불가능하다. 
            https://etst.tistory.com/32
        */

        transition1.condition = gameObject.AddComponent<ToMove>();
        transitions.Add(transition1); 

        transition2 = new Transition();
        transition2.condition = new ToAttack();
        transitions.Add(transition2);

        // FSM - (States, Transitions)
        State sPatrol = this.gameObject.AddComponent<Patrol>();
        sPatrol.enabled = false;
        states.Add(sPatrol);

        State sRecovery = this.gameObject.AddComponent<Recovery>();
        sRecovery.enabled = false;
        states.Add(sRecovery);

        sRecovery.transitions[0].target = sPatrol;
        sPatrol.transitions[0].target = sPatrol;

        states[0].enabled = true;


        // HFSM - (StateInitial)
        stateInitial = sPatrol;
    }
    
}
