using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    private float fireTime = 1.5f;//子弹的发射间隔
    private GameObject bullet;//创建子弹

	void Awake ()
	{
        bullet = Resources.Load<GameObject>("Perfabs/Bullet");

	}


	void Start ()
	{
	
	}
	
	
	void Update ()
	{
        fireTime -= Time.deltaTime;
        if (fireTime <= 0)
        {
            fireTime = 1.5f;
            CreateBullet();
        }
	}

    //创建子弹
    void CreateBullet()
    {
        Vector3 dir = transform.TransformDirection(Vector3.forward);
        //初始化子弹位置
        GameObject go = GameObject.Instantiate(bullet,transform.position,Quaternion.identity) as GameObject;
        Bullet b = go.GetComponent<Bullet>();
        GameObject player = GameObject.Find("Player");
        b.dir = (player.transform.position - transform.position).normalized;
    }

}
