using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHighLevel : State
{
    public List<State> states = new List<State>();
    public State stateInitial;
    public State stateCurrent;

    public override void OnEnable() // ����� ���� Ŭ���� (�� Ŭ����)�� Ȱ��ȭ �Ǹ�, 
    {
        if (stateCurrent == null)
            stateCurrent = stateInitial;

        stateCurrent.enabled = true; // ������ ���ѻ��±�踦 Ȱ��ȭ�Ѵ�
    }

    public override void OnDisable() // ����� ���� Ŭ���� (�� Ŭ����)�� ��Ȱ��ȭ �Ǹ�, 
    {
        base.OnDisable();
        
        stateCurrent.enabled = false;

        foreach (State state in states) // ������ ���ѻ��±�踦 ���������� ��Ȱ��ȭ �Ѵ�.
            state.enabled = false;
    }
}
