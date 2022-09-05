using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Seek : State
{
    Transition transition;

    // << Hard..... (다음 Agent 사용하도록 하자)
    Enemy Obj;
    // >>

    public override void Awake()
    {
        base.Awake();

        transition = gameObject.AddComponent<Transition>();
        transition.condition = gameObject.AddComponent<ToFlee>();
        transitions.Add(transition);

        // << Hard..... (다음 Agent 사용하도록 하자)
        Obj = this.gameObject.GetComponent<Enemy>();
        // >>
    }

    public override void Update()
    {
        Debug.Log("MOVE-SEEK");

        SeekMove();

        DetectTarget();

    }

    void SeekMove()
    {
        if (Obj.target)
        {
            Obj.transform.LookAt(Obj.target.transform);

            Obj.transform.Translate(Vector3.forward * Obj.speedMove * Time.deltaTime);
        }
    }


    void DetectTarget()
    {
        float dis = Vector3.Distance(Obj.transform.position, Obj.target.transform.position);
        if (dis >= Obj.ViewRadius)
        {
            Obj.target = null;
            return;
        }

        float lookingAngle = Obj.transform.eulerAngles.y;

        Vector3 rightDir = AngleToDir(Obj.transform.eulerAngles.y + Obj.ViewAngle * 0.5f);
        Vector3 leftDir = AngleToDir(Obj.transform.eulerAngles.y - Obj.ViewAngle * 0.5f);
        Vector3 lookDir = AngleToDir(lookingAngle);
        Debug.DrawRay(Obj.transform.position, rightDir * Obj.ViewRadius, Color.cyan);
        Debug.DrawRay(Obj.transform.position, leftDir * Obj.ViewRadius, Color.cyan);

        Debug.DrawLine(Obj.transform.position, Obj.target.transform.position, Color.red);
    }


    // 각도를 벡터값으로 바꿔준다
    Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
    }



    // 오브젝트의 반경 값을 그려준다
    void OnDrawGizmos()
    {
        Gizmos.color = new Color32(255, 255, 255, 100);
        Gizmos.DrawWireSphere(transform.position, Obj.ViewRadius);

        Gizmos.color = new Color32(255, 0, 255, 100);
        Gizmos.DrawWireSphere(transform.position, Obj.AttackRadius);

    }
}
