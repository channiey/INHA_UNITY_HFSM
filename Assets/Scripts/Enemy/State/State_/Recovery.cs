using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : State
{
    Transition transition;



    public override void Awake()
    {
        base.Awake();

        transition = new Transition();
        transition.condition = new ToPatrol();
        transitions.Add(transition);
    }
}
