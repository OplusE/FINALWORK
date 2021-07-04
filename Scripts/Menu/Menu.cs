using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 菜单管理类
/// </summary>
public class Menu : MonoBehaviour
{
    private TextMesh textMesh;//获取当前自己的TextMesh组件

    private CameraFollow follow;//得到摄像机脚本

    public Color mouseOverColor;//鼠标移入颜色
    public Color mouseOutColor;//鼠标移出颜色

    public Transform target;//摄像机旋转到的目标位置

	void Start ()
	{
        textMesh = this.GetComponent<TextMesh>();
        follow = Camera.main.GetComponent<CameraFollow>();//获取主摄像机身上的脚本
	}
	
	void Update ()
	{
	
	}

    //鼠标移入
    public void OnMouseEnter()
    {
        textMesh.color = Color.red;
        Music.Instance.PlayEffectMusic(MusicPathConfig.MenuSelectMusic);
    }

    //鼠标移出
    public void OnMouseExit()
    {
        textMesh.color = Color.white;
    }

    //鼠标单击
    public void OnMouseDown()
    {
        Music.Instance.PlayEffectMusic(MusicPathConfig.MenuSelectDownMusic);
        follow.SetTarget(target);//更改摄像机的位置
        switch (textMesh.text)
        {
            case "Play":   SceneManager.LoadScene("Level1");   break;
            case "level1":      SceneManager.LoadScene("Level1");   break;
            case "level2":      SceneManager.LoadScene("Level2");   break;
            case "level3":      SceneManager.LoadScene("Level3");   break;
            case "level4":      SceneManager.LoadScene("Level4");   break;
            case "level5":      SceneManager.LoadScene("Level5");   break;
            case "level6":      SceneManager.LoadScene("Level6");   break;
            case "level7":      SceneManager.LoadScene("Level7");   break;
            case "level8":      SceneManager.LoadScene("Level8");   break;
            case "Exit":        Application.Quit();                 break;
        }
    }
}