using UnityEngine;
using System.Collections;

/// <summary>
/// 过关的门
/// </summary>
public class FinishDoor : MonoBehaviour
{
	
	void Start ()
	{
	}
	
	void Update ()
	{
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            if (LevelManager.Instance.CurScore >= LevelManager.Instance.config.coinNum)
            {
                Music.Instance.PlayEffectMusic(MusicPathConfig.WinMusic);//播放过关声音
                LevelManager.Instance.ui.ShowFinishUI(true);
            }
            else
            {
                LevelManager.Instance.ui.ShowTip();
            }
        }
    }
}
