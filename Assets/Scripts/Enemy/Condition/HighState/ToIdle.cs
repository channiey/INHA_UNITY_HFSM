using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToIdle : Condition
{
    GameObject targetObj = GameObject.FindWithTag("Player");
    GameObject originObj = GameObject.FindWithTag("Enemy");

    float findDis = 8.0f;
    float dis;

    public override bool Test()
    {
        dis = Vector3.Distance(targetObj.transform.position, originObj.transform.position);

        if (dis <= findDis)
            return true;
        else
            return false;

    }
}
