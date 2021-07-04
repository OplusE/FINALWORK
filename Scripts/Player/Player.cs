using UnityEngine;
using System.Collections;

/// <summary>
/// 角色类
/// </summary>
public class Player : MonoBehaviour
{
    private float h;//水平位置
    private float v;//垂直位置
    public float curHp;//英雄当前血量
    public float hpMax = 100;//英雄最大血量
    private float playerMoveSpeed = 10.0f;
    private GameUI gameOver;//创建游戏失败UI
    public bool isFocus;//鼠标是否获得焦点，在游戏失败或成功页面鼠标不需要移动了

    private Rigidbody rig;//当前角色的刚体

    void Awake()
    {
        isFocus = true;
        curHp = hpMax;//血量初始化
    }
	void Start ()
	{
        rig = this.GetComponent<Rigidbody>();
        gameOver = GameObject.FindGameObjectWithTag(TagConfig.Tag_UI).GetComponent<GameUI>();
	}

    void FixedUpdate()//固定时间执行，0.02秒执行
    {
        h = Input.GetAxis(KeyConfig.key_horizontal);
        v = Input.GetAxis(KeyConfig.key_vertical);

        Vector3 dirFoward = Camera.main.transform.TransformDirection(Vector3.forward);//返回摄像机在世界坐标下的正前方向
        dirFoward.Normalize();//将向量单位化
        dirFoward.y = 0;
        rig.AddForce(dirFoward * playerMoveSpeed * v);

        Vector3 dirRight = Camera.main.transform.TransformDirection(Vector3.right);//返回摄像机在世界坐标下的右方向
        dirRight.Normalize();//将向量单位化
        dirRight.y = 0;
        rig.AddForce(dirRight * playerMoveSpeed * h);
    }

	void Update ()
	{
        if(this.transform.position.y < 0)
        {
            gameOver.ShowGameOver(true);//显示闯关失败页面
            isFocus = false;//鼠标失去焦点
        }
	}

    //更新血量
    public void UpdateBolod(float _hp)
    {
        curHp -= _hp;
    }
}
