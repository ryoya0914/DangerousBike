using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject bike;
    public Renderer renderer;
    private BikeController hoge;

    private bool rewardGiven;

    void Start()
    {
        rewardGiven = false;
        hoge = GetComponent<BikeController>();
        AdController.Instance.m_rewardDelegate = GiveReward;
    }

    void Update()
    {

    }

    public void RetrunTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GiveReward()
    {
        rewardGiven = true;
        bike.GetComponent<BikeController>().RunBike();
        StartCoroutine("Invincible");
        GameObject.Find("Canvas/up").GetComponent<Button>().enabled = true;
        GameObject.Find("Canvas/down").GetComponent<Button>().enabled = true;
        GameObject.Find("GameOver").GetComponent<Canvas>().enabled = false;
        GameObject.Find("ForeGroundGenerator").GetComponent<ForeGroundGenerator>().enabled = true;
        GameObject.Find("BackGroundGenerator").GetComponent<BackGroundGenerator>().enabled = true;
    }

    public void RestartGame()
    {
        AdController.Instance.ShowRewardedVideo();
    }

    IEnumerator Invincible()
    {
        bike.SetActive(true);
        bike.tag = "Player";
        int count = 10;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        bike.tag = "player";
    }
}
