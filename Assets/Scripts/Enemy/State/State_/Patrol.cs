using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    Transition transition;

    public override void Awake()
    {
        transition = new Transition();
        transition.condition = new ToRecovery();
        transitions.Add(transition);  
    }

    public override void Update()
    {
        Debug.Log("State - Patrol");
        PatrolMove();

    }


    void PatrolMove()
    {

    }

}
