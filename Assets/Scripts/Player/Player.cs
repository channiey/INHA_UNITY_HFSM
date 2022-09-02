using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;

   
    float hAxis;
    float vAxis;
    Vector3 moveVec;

    private void Start()
    {
    }
    void Update()
    {
        Move();
        Attack();
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
        float Hori = Input.GetAxis("Horizontal");
        float Verti = Input.GetAxis("Vertical");

        Hori = Hori * moveSpeed * Time.deltaTime;
        Verti = Verti * moveSpeed * Time.deltaTime;

        transform.Translate(Vector3.right * Hori);
        transform.Translate(Vector3.forward * Verti);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
    } 
}
