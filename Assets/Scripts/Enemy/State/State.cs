using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public List<Transition> transitions;

    public virtual void Awake()
    {
        // 전이에 대한 설정
        transitions = new List<Transition>();
    }

    public virtual void OnEnable()
    {
        // 초기화 코드 
    }

    public virtual void OnDisable()
    {
        // 종료 코드 
    }

    public virtual void Update()
    {
        // 행위 관련 코드 
    }

    public void LateUpdate()
    {
        foreach (Transition trans in transitions)
        {
            if (trans.condition.Test())
            {
                trans.target.enabled = true;
                this.enabled = false;
                return;
            }
        }
    }
}
