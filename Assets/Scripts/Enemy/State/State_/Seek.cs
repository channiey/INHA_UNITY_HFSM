using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : State
{
    Transition transition;

    public override void Awake()
    {
        transition = new Transition();
        transition.condition = new ToFlee();
        transitions.Add(transition);
    }
}
