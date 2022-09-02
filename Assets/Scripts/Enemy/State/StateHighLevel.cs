using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    StateHighLevel = HFSM(���� Ŭ����)

    FSM�� ������ �ٸ� ���̾ ������ �������ν� HFSM���� ���, Ȯ��� �� �ִ�.

    HFSM�� Ȱ��ȭ �Ǹ�, ������ FSM�� Ȱ��ȭ �Ѵ�.

    HFSM�� ��Ȱ��ȭ �Ǹ�, ������ State���� ��������� ��Ȱ��ȭ �Ѵ�.
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
