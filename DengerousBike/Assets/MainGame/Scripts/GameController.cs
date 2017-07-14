using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject Up;
    [SerializeField] GameObject Down;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject Roads;
    [SerializeField] GameObject ForeGrounds;
    [SerializeField] GameObject BackGrounds;
    [SerializeField] GameObject TruckBlues;
    [SerializeField] GameObject TruckReds;
    [SerializeField] Text scoreLabel;
    [SerializeField] Text coinLabel;
    [SerializeField] Text levelLable;
    [SerializeField] int level = 0;
    [SerializeField] AudioSource MainCamera;
    [SerializeField] GameObject TruckRed01;
    [SerializeField] GameObject TruckRed02;
    [SerializeField] GameObject TruckRed03;
    [SerializeField] BikeController bikeController;
    [SerializeField] Button Restart;
    private bool scoreCount = true;
    private bool coinCount = true;
    private bool timeStart = false;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    float coin = 0;
    float time = 0;
    int countBorder = 5;
    int count = 0;
    private bool rewardGiven;

    void Start()
    {
        rewardGiven = false;
        AdController.Instance.m_rewardDelegate = GiveReward;

        scoreLabel.text = "Score : " + ((int)time).ToString() + "m";
        levelLable.text = "Level: " + level.ToString();
        TruckRed01.SetActive(false);
        TruckRed02.SetActive(false);
        TruckRed03.SetActive(false);
        StartCoroutine(TimeStart());
    }

    void Update()
    {
        if(!timeStart)
        {
            return;
        }
        if (scoreCount == true)
        {
            time += Time.deltaTime;
            scoreLabel.text = "Score : " + ((int)time).ToString() + "m";
        }
        else
        {
            time += 0;
            scoreLabel.text = "Score : " + ((int)time).ToString() + "m";
        }
        if ((int)time >= countBorder)
        {
            countBorder += 20;
            count++;

            if (count <= 4)
            {
                LevelUp();
            }
        }
        if (coinCount == true)
        {
            coin += 0.005f *level;
            coinLabel.text = ((int)coin).ToString();
        }
        else
        {
            coin += 0;
            coinLabel.text = ((int)coin).ToString();
        }
    }



    public void RetrunTitle()
    {
        ScroreSave();
        CoinSave();
        SceneManager.LoadScene("Title");
    }

    public void GiveReward()
    {
        bikeController.ChangeInvincible();
        rewardGiven = true;
        MainCamera.Play();
        gameover.GetComponent<Canvas>().enabled = false;
        Up.GetComponent<Button>().interactable = true;
        Down.GetComponent<Button>().interactable = true;
        scoreCount = true;
        coinCount = true;
        foreach (Transform Child in Roads.transform)
        {
            Child.gameObject.GetComponent<ScrollObject>().enabled = true;
        }
        foreach (Transform Child in ForeGrounds.transform)
        {
            Child.gameObject.GetComponent<ScrollObject>().enabled = true;
        }
        foreach (Transform Child in BackGrounds.transform)
        {
            Child.gameObject.GetComponent<ScrollObject>().enabled = true;
        }
        foreach (Transform Child in TruckBlues.transform)
        {
            Child.gameObject.GetComponent<ObstacleScrollObject>().enabled = true;
        }
        foreach (Transform Child in TruckReds.transform)
        {
            Child.gameObject.GetComponent<ObstacleScroll>().enabled = true;
        }


    }
    public void RestartGame()
    {
#if !UNITY_EDITOR && !UNITY_STANDALONE
        AdController.Instance.ShowRewardedVideo();
#endif

        GiveReward();
    }

    public void GameOver()
    {
        if(AdController.Instance.isRewardedVideoReady())
        {

        }
        else
        {
            Restart.interactable = false;
        }
        MainCamera.Stop();
        gameover.GetComponent<Canvas>().enabled = true;
        Up.GetComponent<Button>().interactable = false;
        Down.GetComponent<Button>().interactable = false;
        scoreCount = false;
        coinCount = false;
        foreach(Transform Child in Roads.transform)
        {
            Child.gameObject.GetComponent<ScrollObject>().enabled = false;
        }
        foreach (Transform Child in ForeGrounds.transform)
        {
            Child.gameObject.GetComponent<ScrollObject>().enabled = false;
        }
        foreach (Transform Child in BackGrounds.transform)
        {
            Child.gameObject.GetComponent<ScrollObject>().enabled = false;
        }
        foreach (Transform Child in TruckBlues.transform)
        {
            Child.gameObject.GetComponent<ObstacleScrollObject>().enabled = false;
        }
        foreach (Transform Child in TruckReds.transform)
        {
            Child.gameObject.GetComponent<ObstacleScroll>().enabled = false;
        }


    }

    IEnumerator TimeStart()
    {
        yield return new WaitForSeconds(2);
        timeStart = true;

    }

    public void ScroreSave()
    {
        if (time > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)time);
        }
    }

    public void CoinSave()
    {
       int coinNow = PlayerPrefs.GetInt("Coin",0) + (int)coin;
       PlayerPrefs.SetInt("Coin", coinNow);
    }

    public void LevelUp()
    {
        if (count == 1) { level = 1; }
        if (count == 2) { level = 2; }
        if (count == 3) { level = 3; TruckRed01.SetActive(true); }
        if (count == 4) { level = 4; TruckRed02.SetActive(true); }
        if (count == 5) { level = 5; TruckRed03.SetActive(true); }
        levelLable.text = "Level: " + level.ToString();
    }
}
