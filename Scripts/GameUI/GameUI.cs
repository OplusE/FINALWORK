using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// UI显示类
/// </summary>
public class GameUI : MonoBehaviour
{
    public Text txtCoinNum;     //收集的金币数量文本
    public Text txtLevelNum;    //显示当前关卡文本
    public Text txtTip;         //文字提示的文本
    public GameObject goFinish; //过关之后显示的UI
    public GameObject gameOver; //当前关卡失败显示的UI

    private Image img;//血条图片
    private Text txtHp;//血条文本

    void Start()
    {
        txtLevelNum.text = "第" + Application.loadedLevel.ToString() + "关";
        img = GameObject.Find("HPValue").GetComponent<Image>();
        txtHp = GameObject.Find("HPText").GetComponent<Text>();
    }

	void Update ()
	{
        //血条图片更新
        img.fillAmount = LevelManager.Instance.player.curHp / LevelManager.Instance.player.hpMax;
        txtHp.text = LevelManager.Instance.player.curHp.ToString("f1");//血条文本更新
	}

    //更新分数
    public void UpdateScore(int curScore, int maxScore)
    {
        txtCoinNum.text = curScore + "/" + maxScore;
    }

    //控制当前关卡过关的UI显示
    public void ShowFinishUI(bool isShow)
    {
        goFinish.SetActive(isShow);
        LevelManager.Instance.player.isFocus = false;//鼠标失去焦点

        //Rigidbody rig = LevelManager.Instance.player.GetComponent<Rigidbody>();
        //rig.useGravity = false;
    }

    //控制分数没有收集够的提示显示
    public void ShowTip()
    {
        StartCoroutine(TipDisplayManage());//开启协程
    }

    //控制当前关卡失败的提示显示
    public void ShowGameOver(bool isShow)
    {
        gameOver.SetActive(isShow);
        LevelManager.Instance.player.isFocus = false;//小球失去焦点
    }

    //单击下一关按钮
    public void OnBtnNext()
    {
        SceneManager.LoadScene(LevelManager.Instance.config.nextStage);
    }

    //单击再来一次按钮
    public void OnTryAgin()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    //单击主菜单按钮
    public void OnBtnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //控制提示文字的关闭
    IEnumerator TipDisplayManage()
    {
        txtTip.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);//两秒后提示消失
        txtTip.gameObject.SetActive(false);
    }
}