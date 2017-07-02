using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject bike;
    [SerializeField]
    GameObject Up;
    [SerializeField]
    GameObject Down;
    [SerializeField]
    GameObject GameOver;
    [SerializeField]
    GameObject ForeGroundGenerator;
    [SerializeField]
    GameObject BackGroundGenerator;
    [SerializeField] Renderer renderer;

    private bool rewardGiven;
    void Start()
    {
        rewardGiven = false;
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
        Up.GetComponent<Button>().enabled = true;
        Down.GetComponent<Button>().enabled = true;
        GameOver.GetComponent<Canvas>().enabled = false;
        ForeGroundGenerator.GetComponent<GroundGenerator>().enabled = true;
        BackGroundGenerator.GetComponent<GroundGenerator>().enabled = true;
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
