using UnityEngine;
using System.Collections;

/// <summary>
/// 加速板
/// </summary>
public class SpeedBoard : MonoBehaviour
{
    public Vector3 dir;//往指定的方向施加力
    public float speed = 300.0f;//施加力量的大小
	
	void Start ()
	{
	
	}
	
	
	void Update ()
	{
	
	}

    void OnCollisionEnter(Collision c)
    {
        Music.Instance.PlayEffectMusic(MusicPathConfig.SpeedBoardMusic);//播放声音
        c.collider.gameObject.GetComponent<Rigidbody>().AddForce(dir * speed);
    }

}
