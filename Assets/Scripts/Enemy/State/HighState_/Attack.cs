using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateHighLevel
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
    }
}
