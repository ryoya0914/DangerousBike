using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject bike;
    [SerializeField] GameObject Up;
    [SerializeField] GameObject Down;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject roads;
    [SerializeField] GameObject ForeGround;
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject Truck;
    [SerializeField] ScoreController scorecontroller;
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
        scorecontroller.ScroreSave();
        SceneManager.LoadScene("Title");
    }

    public void GiveReward()
    {
        rewardGiven = true;
        bike.GetComponent<ScrollObject>().enabled = true;
        Up.GetComponent<Button>().enabled = true;
        Down.GetComponent<Button>().enabled = true;
        gameover.GetComponent<Canvas>().enabled = false;
        ForeGround.GetComponent<ScrollObject>().enabled = true;
        BackGround.GetComponent<ScrollObject>().enabled = true;
    }
    public void RestartGame()
    {
        AdController.Instance.ShowRewardedVideo();
    }

    public void GameOver()
    {
        gameover.GetComponent<Canvas>().enabled = true;
    }

}
