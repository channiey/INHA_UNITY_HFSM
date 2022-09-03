using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : State
{
    Transition transition;

    public override void Awake()
    {

        base.Awake();

        transition = new Transition();
        transition.condition = new ToSeek();
        transitions.Add(transition);
    }
}
