using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class JumpBoard : MonoBehaviour
{
    public Vector3 dir;//往指定的方向施加力
    public float speed = 400.0f;//施加力量的大小
	void Awake ()
	{
	
	}


	void Start ()
	{
	
	}
	
	
	void Update ()
	{
	
	}

    void OnCollisionEnter(Collision c)
    {
        Music.Instance.PlayEffectMusic(MusicPathConfig.JumpBoardMusic);//播放声音
        c.gameObject.GetComponent<Rigidbody>().AddForce(dir * speed);
    }

}
