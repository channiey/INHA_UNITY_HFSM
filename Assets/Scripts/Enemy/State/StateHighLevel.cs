using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    StateHighLevel = HFSM(현재 클래스)

    FSM은 스스로 다른 레이어나 계층을 가짐으로써 HFSM으로 향상, 확장될 수 있다.

    HFSM이 활성화 되면, 내부의 FSM을 활성화 한다.

    HFSM이 비활성화 되면, 내부의 State들을 재귀적으로 비활성화 한다.
*/


/*      
        StateHighLevel(HFSM)         State(FSM)
        - IDLE                        Patrol  /  Recovery
        - MOVE                        Flee    /  Seek
        - ATTACK                      Basic   /  Skill
*/


public class StateHighLevel : State
{
    public List<State> states;
    public State stateInitial;
    public State stateCurrent;

    public override void OnEnable()
    {
        if (stateCurrent == null)
            stateCurrent = stateInitial;

        stateCurrent.enabled = true;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        
        stateCurrent.enabled = false;

        foreach (State state in states)
            state.enabled = false;
    }
}
