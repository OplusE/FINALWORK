using UnityEngine;
using System.Collections;

/// <summary>
/// 摄像机随鼠标和键盘的WSAD移动视角
/// </summary>
public class CameraLook : MonoBehaviour
{

    public Transform target;//摄像机要跟随的目标
    public float distance = 5.0f;//摄像机和目标的距离 
    private Vector3 cameraAngel;//摄像机的旋转角度

    public float speedX = 200.0f;//鼠标水平方向的移动速度
    public float speedY = 200.0f;//鼠标垂直方向的移动速度

    public float rotateSpeed = 30;//一帧旋转的角度

    public float minY = 10.0f;//摄像机在鼠标Y轴方向的最小角度
    public float maxY = 90.0f;//摄像机在鼠标Y轴方向的最大角度

    void Start()
    {
        GameObject go = GameObject.Find(TagConfig.Tag_Player);
        if (go != null)
        {
            target = go.transform;
        } 

        //保存摄像机原始的旋转角度
        cameraAngel.x = this.transform.eulerAngles.x;
        cameraAngel.y = this.transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftAlt) && LevelManager.Instance.player.isFocus)//按住Alt键调节鼠标鼠标
        {
            float h = Input.GetAxis(KeyConfig.key_mouseX);
            float v = Input.GetAxis(KeyConfig.key_mouseY);

            //调整摄像机随着鼠标的移动改变角度
            cameraAngel.x += h * speedX * Time.deltaTime;
            cameraAngel.y -= v * speedY * Time.deltaTime;
            cameraAngel.y = Mathf.Clamp(cameraAngel.y, minY, maxY);

            //已知一个欧拉角转换成四元素
            Quaternion q = Quaternion.Euler(cameraAngel.y, cameraAngel.x, 0);
            transform.rotation = q;//将旋转的角度赋给摄像机

            //向量左乘一个角度得到旋转之后的新向量
            transform.position = target.position + q * new Vector3(0, 0, -distance);
        }
        Camera.main.transform.localScale = new Vector3(0,Input.GetAxis(KeyConfig.key_mouseScoreWheel),0);
    }
}
