using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : State
{
    Transition transition;

    public override void Awake()
    {
        base.Awake();

        transition = new Transition();
        transition.condition = new ToBasicAttack();
        transitions.Add(transition);
    }
}
