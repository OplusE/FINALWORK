using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 移动板
/// </summary>
class MoveBoard : MonoBehaviour
{
    public Vector3 v1, v2;
    private Vector3 vTarget;//需要移动到的目标
    public float moveSpeed = 0.1f;//平台移动的速度

    public Collider[] colliders;

    void Awake()
    {
    }

    void Start()
    {
        //v1 = transform.GetChild(0).position;
        //v2 = transform.GetChild(1).position;
        //Transform transDoor = transform.Find("Door");
        //colliders = transform.GetComponentInChildren<Collider>();
        //if (transDoor != null)
        //{
        int size = this.transform.childCount;
        colliders = new Collider[size];
        for (int i = 0; i < size; i++)
        {
            colliders[i] = this.transform.GetChild(i).GetComponent<Collider>();
        }

        //colliders = transform.GetComponentInChildren<Collider>();
        //}

        vTarget = v1;
    }

    void FixedUpdate()
    {
        //做插值运算，Slerp会平滑一点
        transform.position = Vector3.Slerp(transform.position, vTarget, Time.deltaTime * moveSpeed);
        float len = Vector3.Distance(transform.position, vTarget);
        if (len <= 0.007f)
        {
            vTarget = vTarget == v1 ? v2 : v1;
        }

        for (int i = 0; i < colliders.Length; i++)
        {
            if (len <= 0.2f)
            {
                if (!colliders[i].isTrigger)
                {
                    colliders[i].isTrigger = true;
                }
            }
            else
            {
                if (colliders[i].isTrigger)
                {
                    colliders[i].isTrigger = false;
                }

            }
        }

    }
}