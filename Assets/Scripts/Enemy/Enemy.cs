using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    HFSM - Hierachical Finite State Machines (������ ���� ���� ���)



    StateHighLevel = HFSM(���� Ŭ����)

    FSM�� ������ �ٸ� ���̾ ������ �������ν� HFSM���� ���, Ȯ��� �� �ִ�.

    HFSM�� Ȱ��ȭ �Ǹ�, ������ FSM�� Ȱ��ȭ �Ѵ�.

    HFSM�� ��Ȱ��ȭ �Ǹ�, ������ State���� ��������� ��Ȱ��ȭ �Ѵ�.
     


        StateHighLevel(HFSM)         State(FSM)
        - IDLE                        Patrol  /  Recovery
        - MOVE                        Flee    /  Seek
        - ATTACK                      Basic   /  Skill
*/


public class Enemy : MonoBehaviour
{
    private List<State> StateHighlist;

    // Basic Variables
    public float Health = 100;
    public float Mana = 100;
    public float speedMove = 10;
    public float speedRotate = 100;

    // Viewing Angle Variables
    [Range(0f, 360f)] public float ViewAngle = 90.0f;
    public float ViewRadius = 15.0f;
    public float AttackRadius = 3.0f;
    public LayerMask TargetMask;
    public LayerMask ObstacleMask;

    public List<Collider> hitTargetList = new List<Collider>();
    public RaycastHit hit;

    // Patrol
    public float disAcc = 0.0f;
    public float maxDisAcc = 15.0f;

    public GameObject target;

    private void Awake()
    {
        StateHighlist = new List<State>();
    }
    void Start()
    {
        // Set the HFSM
        StateHighLevel sIdle = this.gameObject.AddComponent<Idle>();
        sIdle.enabled = false;
        StateHighLevel sAttack = this.gameObject.AddComponent<Attack>();
        sAttack.enabled = false;

        StateHighLevel sMove = this.gameObject.AddComponent<Move>();
        sMove.enabled = false;


        StateHighlist.Add(sIdle);
        StateHighlist.Add(sAttack);
        StateHighlist.Add(sMove);

        // Set the Transition Target of HFSM
        sIdle.transitions[0].target = sMove;
        sIdle.transitions[1].target = sAttack;
        
        sMove.transitions[0].target = sIdle;
        sMove.transitions[1].target = sAttack;

        sAttack.transitions[0].target = sIdle;
        sAttack.transitions[1].target = sMove;

        StateHighlist[0].enabled = true;


        Debug.Log("Complete the Set Enemy HFSM!");
    }


    
}

