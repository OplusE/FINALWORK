using UnityEngine;
using System.Collections;

/// <summary>
/// 开始菜单摄像机视角的切换
/// </summary>
public class CameraFollow : MonoBehaviour
{

    private Transform target;//摄像机要旋转到的目标点
    private float speedAngle = 5.0f;//摄像机旋转的速度

    void Start()
    {
    }

    void LateUpdate()//在Update后执行
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion aim = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, aim, speedAngle * Time.deltaTime);
        }
    }


    public void SetTarget(Transform t)
    {
        target = t;
    }
}
