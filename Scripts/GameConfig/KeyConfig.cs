using UnityEngine;
using System.Collections;

/// <summary>
/// 管理游戏中鼠标键盘按键
/// </summary>
public class KeyConfig
{
    private KeyConfig() { }//构造函数私有化，不需要创建这个类的实例

    public const string key_horizontal = "Horizontal";//水平方向
    public const string key_vertical = "Vertical";    //垂直方向
    public const string key_mouseX = "Mouse X";       //鼠标水平方向
    public const string key_mouseY = "Mouse Y";       //鼠标垂直方向
    public const string key_mouseScoreWheel = "Mouse ScrollWheel";       //鼠标滑轮
}