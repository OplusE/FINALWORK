using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏管理器
/// </summary>
public class LevelManager : Sinleton<LevelManager>
{
    //游戏中时只有一个管理
    //private static LevelManager instance;//单例模式
    //public static LevelManager Instance
    //{
    //    get { return LevelManager.instance; }
    //}

    public bool isFinish = false;//当前关卡是否过关

    public Player player;//创建人物对象
    public GameUI ui;//创建UI对象
    public LevelConfig config;//创建过关条件配置

    private int curScore;//当前分数
    public int CurScore
    {
        get { return curScore; }
        set
        {
            curScore = value;
            ui.UpdateScore(curScore, config.coinNum);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        //Music.Instance.PlayBGMusic(MusicPathConfig.BGMusic);
    }

    //void Awake()
    //{
    //    instance = this;//单例模式
    //}

	void Start ()
	{
        GameObject go = GameObject.Find("Player");//获取人物
        if (go != null)
        {
            player = go.GetComponent<Player>();
        }

        go = GameObject.Find("UI");//获取UI
        if (go != null)
        {
            ui = go.GetComponent<GameUI>();
            ui.UpdateScore(curScore, config.coinNum);
        }
	}
	
	void Update ()
	{
	
	}
}