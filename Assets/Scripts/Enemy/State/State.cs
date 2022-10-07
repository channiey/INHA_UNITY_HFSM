using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public List<Transition> transitions;

    public virtual void Awake()
    {
        // ���̿� ���� ����
        transitions = new List<Transition>();
    }

    public virtual void OnEnable()
    {
        // �ʱ�ȭ �ڵ� 
    }

    public virtual void OnDisable()
    {
        // ���� �ڵ� 
    }

    public virtual void Update()
    {
        // ���� ���� �ڵ� 
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
