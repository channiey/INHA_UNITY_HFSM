using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<State> StateHighlist;

    // Basic Variables
    [SerializeField] float Health;
    [SerializeField] float Mana;
    [SerializeField] float speedMove;
    [SerializeField] float speedRotate;

    // Viewing Angle Variables
    [Range(0f, 360f)] [SerializeField] float ViewAngle = 90.0f;
    [SerializeField] float ViewRadius = 5.0f;
    [SerializeField] LayerMask TargetMask;
    [SerializeField] LayerMask ObstacleMask;

    List<Collider> hitTargetList = new List<Collider>();
    RaycastHit hit;

    
    //void Start()
    //{

    //    // Set the HFSM
    //    StateHighLevel sIdle = this.gameObject.AddComponent<Idle>();
    //    sIdle.enabled = false;
    //    StateHighLevel sAttack = this.gameObject.AddComponent<Attack>();
    //    sAttack.enabled = false;
    //    StateHighLevel sMove = this.gameObject.AddComponent<Move>();
    //    sMove.enabled = false;

    //    StateHighlist.Add(sIdle);
    //    StateHighlist.Add(sAttack);
    //    StateHighlist.Add(sMove);


    //    // Set the Transition Target of HFSM
    //    sIdle.transitions[0].target = sMove;
    //    sIdle.transitions[1].target = sAttack;
    //    sMove.transitions[0].target = sIdle;
    //    sMove.transitions[1].target = sAttack;
    //    sAttack.transitions[0].target = sIdle;
    //    sAttack.transitions[1].target = sMove;

    //    StateHighlist[0].enabled = true;
    //}


    void Update()
    {
        Move();
        SetTarget();
    }

    void SetTarget()
    {
        /*
        1. ���� ���� ���� Ư�� layer�� ������Ʈ �ν�

        2. �ش� ������Ʈ�� ��ġ�� �þ߰� ���� ��

        3. �ش� ������Ʈ�� �� ���̿� ��ֹ��� ������ �Ǵ�
        */

        float lookingAngle = transform.eulerAngles.y;  // ĳ���Ͱ� �ٶ󺸴� ������ ����

        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + ViewAngle * 0.5f); // ������ ����3�� ��ȯ
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - ViewAngle * 0.5f);
        Vector3 lookDir = AngleToDir(lookingAngle);
        Debug.DrawRay(transform.position, rightDir * ViewRadius, Color.cyan);
        Debug.DrawRay(transform.position, leftDir * ViewRadius, Color.cyan);
        Debug.DrawRay(transform.position, lookDir * ViewRadius, Color.yellow);

        hitTargetList.Clear(); // ?
        Collider[] Targets = Physics.OverlapSphere(transform.position, ViewRadius, TargetMask); // �ݰ� ��, Ư�� ���̾ ���� �ݶ��̴� ��ȯ

        if (Targets.Length == 0) return;

        foreach (Collider EnemyCol in Targets)
        {
            Vector3 targetPos = EnemyCol.transform.position;
            Vector3 targetDir = (targetPos - transform.position).normalized;

            float targetAngle = Mathf.Acos(Vector3.Dot(lookDir, targetDir)) * Mathf.Rad2Deg;
            if (targetAngle <= ViewAngle * 0.5f && !Physics.Raycast(transform.position, targetDir, ViewRadius, ObstacleMask))
            {
                hitTargetList.Add(EnemyCol);          
                Debug.DrawLine(transform.position, targetPos, Color.red);              
            }
        }
    }


    // ������ ���Ͱ����� �ٲ��ش�
    Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad; 
        return new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
    }



    // ������Ʈ�� �ݰ� ���� �׷��ش�
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ViewRadius);
    }



    void Move()
    {
        float rotate = Input.GetAxis("Horizontal"); // 0 or 1
        float move = Input.GetAxis("Vertical");

        rotate = rotate * speedRotate * Time.deltaTime; // ȸ����
        move = move * speedMove * Time.deltaTime; // �̵��� 

        transform.Rotate(Vector3.up * rotate);
        transform.Translate(Vector3.forward * move);
    }
}




/*
// Raycast & Search (���Ǿ� ����ĳ��Ʈ)
[SerializeField] float rayRadius;
[SerializeField] bool getTarget = false;
private RaycastHit[] rayHits;
private Ray ray = new Ray();
void SearchRaycast()
{
    ray.origin = this.transform.position;
    ray.direction = this.transform.up;
    rayHits = Physics.SphereCastAll(ray.origin, rayRadius, Vector3.up, 0f);

    foreach (RaycastHit hit in rayHits)
    {
        if (hit.collider.gameObject.tag == "Player")
        {
            Debug.Log("Detected the Player");
        }
    }
}
void OnDrawGizmos()
{
    //Gizmos.color = new Color32(0, 255, 0, 50);
    //Gizmos.DrawSphere(ray.origin, rayRadius);
}

*/