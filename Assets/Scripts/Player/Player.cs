using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Basic Variables
    [SerializeField] float Health = 100;
    [SerializeField] float Mana = 100;
    [SerializeField] float speedMove = 10;
    [SerializeField] float speedRotate = 100;

    // Viewing Angle Variables
    [Range(0f, 360f)] [SerializeField] float ViewAngle = 90.0f;
    [SerializeField] float ViewRadius = 5.0f;
    [SerializeField] LayerMask TargetMask;
    [SerializeField] LayerMask ObstacleMask;

    List<Collider> hitTargetList = new List<Collider>();
    RaycastHit hit;


    private void Start()
    {
    }
    void Update()
    {
        Move();
        //Attack();
        DetectTarget();

    }

    private void FixedUpdate()
    {

    }


    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack!");
        }
    }

    void Move()
    {
        float rotate = Input.GetAxis("Horizontal"); // 0 or 1
        float move = Input.GetAxis("Vertical");

        rotate = rotate * speedRotate * Time.deltaTime; // 회전량
        move = move * speedMove * Time.deltaTime; // 이동량 

        transform.Rotate(Vector3.up * rotate);
        transform.Translate(Vector3.forward * move);
    }

    void DetectTarget()
    {
        /*
        1. 범위 내로 들어온 특정 layer의 오브젝트 인식

        2. 해당 오브젝트의 위치와 시야각 각도 비교

        3. 해당 오브젝트와 나 사이에 장애물이 없는지 판단
        */

        float lookingAngle = transform.eulerAngles.y;  // 캐릭터가 바라보는 방향의 각도

        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + ViewAngle * 0.5f); // 각도를 벡터3로 변환
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - ViewAngle * 0.5f);
        Vector3 lookDir = AngleToDir(lookingAngle);
        Debug.DrawRay(transform.position, rightDir * ViewRadius, Color.yellow);
        Debug.DrawRay(transform.position, leftDir * ViewRadius, Color.yellow);
       // Debug.DrawRay(transform.position, lookDir * ViewRadius, Color.yellow);

        hitTargetList.Clear(); // ?
        Collider[] Targets = Physics.OverlapSphere(transform.position, ViewRadius, TargetMask); // 반경 내, 특정 레이어를 가진 콜라이더 반환

        if (Targets.Length == 0) return;

        foreach (Collider Col in Targets)
        {
            Vector3 targetPos = Col.transform.position;
            Vector3 targetDir = (targetPos - transform.position).normalized;

            float targetAngle = Mathf.Acos(Vector3.Dot(lookDir, targetDir)) * Mathf.Rad2Deg;
            if (targetAngle <= ViewAngle * 0.5f && !Physics.Raycast(transform.position, targetDir, ViewRadius, ObstacleMask))
            {
                hitTargetList.Add(Col);
                //Debug.DrawLine(transform.position, targetPos, Color.red);
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
        //Gizmos.color = new Color32(255, 255, 255, 100);
        //Gizmos.DrawWireSphere(transform.position, ViewRadius);
    }
}
