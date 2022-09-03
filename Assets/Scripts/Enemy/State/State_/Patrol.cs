using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    Transition transition;

    // << Hard..... (다음 Agent 사용하도록 하자)
    Enemy Obj;
    // >>

    

    public override void Awake()
    {
        base.Awake();

        transition = new Transition();
        transition.condition = new ToRecovery();
        transitions.Add(transition);

        // << Hard..... (다음 Agent 사용하도록 하자)
        Obj = this.gameObject.GetComponent<Enemy>();
        // >>
    }

    public override void Update()
    {
        Move();
        DetectTarget();
    }

    

    void DetectTarget()
    {
        float lookingAngle = Obj.transform.eulerAngles.y;  
        
        Vector3 rightDir = AngleToDir(Obj.transform.eulerAngles.y + Obj.ViewAngle * 0.5f); 
        Vector3 leftDir = AngleToDir(Obj.transform.eulerAngles.y - Obj.ViewAngle * 0.5f);
        Vector3 lookDir = AngleToDir(lookingAngle);
        Debug.DrawRay(Obj.transform.position, rightDir * Obj.ViewRadius, Color.cyan);
        Debug.DrawRay(Obj.transform.position, leftDir * Obj.ViewRadius, Color.cyan);
        //Debug.DrawRay(transform.position, lookDir * Obj.ViewRadius, Color.yellow);

        Obj.hitTargetList.Clear(); // ?
        Collider[] Targets = Physics.OverlapSphere(Obj.transform.position, Obj.ViewRadius, Obj.TargetMask); 

        if (Targets.Length == 0) return;

        foreach (Collider Col in Targets)
        {
            Vector3 targetPos = Col.transform.position;
            Vector3 targetDir = (targetPos - Obj.transform.position).normalized;

            float targetAngle = Mathf.Acos(Vector3.Dot(lookDir, targetDir)) * Mathf.Rad2Deg;

            if (targetAngle <= Obj.ViewAngle * 0.5f 
                && !Physics.Raycast(Obj.transform.position, targetDir, Obj.ViewRadius, Obj.ObstacleMask) 
                && Col.gameObject.tag == "Player")
            {               
                Debug.DrawLine(Obj.transform.position, targetPos, Color.red);
                Obj.target = Col.gameObject;                    
            }
            else
            {
                Obj.target = null;
            }
        }
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



    void Move()
    {
        if (Obj.disAcc >= Obj.maxDisAcc)
        {
            transform.Rotate(Vector3.up * -90.0f);
            Obj.disAcc = 0.0f;
        }

        float move = 1 * Obj.speedMove * Time.deltaTime;
        Obj.disAcc += move;

        transform.Translate(Vector3.forward * move);
    }
}
