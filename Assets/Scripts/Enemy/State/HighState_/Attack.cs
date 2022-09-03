using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateHighLevel
{
    // HFSM
    [SerializeField] Transition transition1;
    [SerializeField] Transition transition2;

    public override void Awake()
    {
        base.Awake();

        // HFSM
        transition1 = new Transition();
        transition1.condition = new ToIdle();
        transitions.Add(transition1);

        transition2 = new Transition();
        transition2.condition = new ToMove();
        transitions.Add(transition2);

        // FSM
        State sBasicAttack = this.gameObject.AddComponent<BasicAttack>();
        sBasicAttack.enabled = false;
        states.Add(sBasicAttack);

        State sSkillAttack = this.gameObject.AddComponent<SkillAttack>();
        sSkillAttack.enabled = false;
        states.Add(sSkillAttack);

        sBasicAttack.transitions[0].target = sSkillAttack;
        sSkillAttack.transitions[0].target = sBasicAttack;

        // HFSM - (StateInitial)
        stateInitial = sBasicAttack;
    }
}
