using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public List<Transition> transitions;


    public virtual void Awake()
    {
        transitions = new List<Transition>();

        // 전이에 대한 설정
    }

    public virtual void OnEnable()
    {
        // 초기화 코드 작성
    }

    public virtual void OnDisable()
    {
        // 종료코드 작성
    }

    public virtual void Update()
    {
        // 행위 관련 코드 작성
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
