using UnityEngine;
using System.Collections;

/// <summary>
/// 金币类
/// </summary>
public class Coin : MonoBehaviour
{
    private float coinRotate = 100.0f;//金币旋转的速度，一帧100度
	
	void Start ()
	{
        Collider c = this.gameObject.GetComponent<Collider>();
        c.isTrigger = true;
	}
	
	void Update ()
	{
        this.transform.Rotate(Vector3.up, Time.deltaTime * coinRotate, Space.World);
	}

    //触发器
    void OnTriggerEnter(Collider c)
    {
        Music.Instance.PlayEffectMusic(MusicPathConfig.CoinMusic);//播放吃到金币声音
        LevelManager.Instance.CurScore++;//单例模式可以用类名直接点出属性
        GameObject.Destroy(this.gameObject);
    }
}
