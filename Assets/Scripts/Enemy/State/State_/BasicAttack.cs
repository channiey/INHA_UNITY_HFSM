using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : State
{
    Transition transition;

    public override void Awake()
    {
        transition = new Transition();
        transition.condition = new ToSkillAttack();
        transitions.Add(transition);
    }
}
