using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHighLevel : State
{
    public List<State> states = new List<State>();
    public State stateInitial;
    public State stateCurrent;

    public override void OnEnable() // 고수준 상태 클래스 (현 클래스)가 활성화 되면, 
    {
        if (stateCurrent == null)
            stateCurrent = stateInitial;

        stateCurrent.enabled = true; // 내부의 유한상태기계를 활성화한다
    }

    public override void OnDisable() // 고수준 상태 클래스 (현 클래스)가 비활성화 되면, 
    {
        base.OnDisable();
        
        stateCurrent.enabled = false;

        foreach (State state in states) // 내부의 유한상태기계를 순차적으로 비활성화 한다.
            state.enabled = false;
    }
}
