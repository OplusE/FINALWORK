using UnityEngine;
using System.Collections;

[System.Serializable]
/// <summary>
/// 过关条件管理类
/// </summary>
public class LevelConfig
{
    public int coinNum;     //金币的收集数量
    public string nextStage;//下一关的名字
}