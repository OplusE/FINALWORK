using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Vector3 dir;//获得人物的方向
    private float bulletSpeed = 10.0f;//子弹的发射速度
    private GameObject player;

	void Awake ()
	{
        
	}


	void Start ()
	{
        player = GameObject.Find("Player");
        GameObject.Destroy(this.gameObject, 10.0f);
	}
	
	
	void Update ()
	{
        transform.Translate(dir * bulletSpeed * Time.deltaTime, Space.World);
        
        //dir = (player.transform.position - transform.position).normalized;
        //在运动的过程中自动修正自己的方向
        //transform.Translate(dir * bulletSpeed * Time.deltaTime, Space.World);

        //在运动的过程中自动修正角度
        Quaternion tarRotate = Quaternion.LookRotation(dir);
        Quaternion qua = Quaternion.Slerp(transform.rotation,tarRotate,Time.deltaTime * 5);
        transform.rotation = qua;
	}

    void OnCollisionEnter(Collision c)
    {
        if (!c.collider.CompareTag("Npc"))
        { 
            if(c.collider.CompareTag("Player"))
            {
                Music.Instance.PlayEffectMusic(MusicPathConfig.BulletMusic);//播放爆咋声音
                LevelManager.Instance.player.UpdateBolod(0.1f);
                GameObject.Destroy(this.gameObject);
            }
        }
    }



}
