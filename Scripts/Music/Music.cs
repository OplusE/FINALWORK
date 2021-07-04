using UnityEngine;
using System.Collections;

public class Music : Sinleton<Music>
{
    //背景音乐，比较长的音乐(mp3,ogg)
    private AudioSource audioBGMusic;//背景音效
    private AudioSource audioEffect;//音效
    public string path;//音乐路径

    //调节背景音乐大小
    public float VolumBgMusic
    {
        get { return audioBGMusic.volume; }
        set { audioBGMusic.volume = value; }
    }

    //调节音效大小
    public float VolumEffect
    {
        get { return audioEffect.volume; }
        set { audioEffect.volume = value; }
    }

	protected override void Awake ()
	{
	    base.Awake();
        audioBGMusic = this.gameObject.AddComponent<AudioSource>();//添加音乐组件
        audioEffect = this.gameObject.AddComponent<AudioSource>();
        audioBGMusic.playOnAwake = true;//游戏开始播放音乐
        audioBGMusic.loop = true;//循环播放

        PlayBGMusic(MusicPathConfig.BGMusic);//游戏一运行直接放音乐
	}

	void Start ()
	{
        
	}	
	void Update ()
	{
	
	}

    //播放背景音乐
    public void PlayBGMusic(string _name)
    {
        string oldName = "";//存放当前正在播放的音乐名字
        if (audioBGMusic.clip != null)
        {
            oldName = audioBGMusic.clip.name;
        }
        if (!string.IsNullOrEmpty(_name) && oldName != _name)//确保根目录不为空
        {
            string tempPath = _name;//新的音乐路径
            if (!string.IsNullOrEmpty(path))//判断资源目录不为空
            {
                tempPath = path + "/" + _name;
            }

            AudioClip clip = Resources.Load<AudioClip>(tempPath);
            if (clip != null)
            {
                audioBGMusic.clip = clip;//设置音源
                audioBGMusic.Play();//播放音乐
            }
        }

        
    }

    //播放音效
    public void PlayEffectMusic(string _name)
    {
        string tempPath = _name;
        if (!string.IsNullOrEmpty(path))//确保根目录不为空
        {
            tempPath = path + "/" + _name;
        }
        AudioClip clip = Resources.Load<AudioClip>(tempPath);
        if (clip != null)
        {
            audioEffect.clip = clip;//设置音源
            audioEffect.PlayOneShot(clip);//播放短音效
        }
    }
}
