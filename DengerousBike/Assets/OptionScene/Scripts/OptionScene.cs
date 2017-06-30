using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionScene : MonoBehaviour {

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    GameObject LangSelPrefab;

    [SerializeField]
    GameObject rewardButton;

    [SerializeField]
    Text rewardCount;

    private bool rewardReady = false;
    private int rewardedTimes = 0;

    private int frameSkip = 0;

	// Use this for initialization
	void Start ()
    {
        rewardReady = AdController.Instance.isRewardedVideoReady();
        rewardedTimes = PlayerPrefs.GetInt("RewardedTimes", 0);
	}
	
    public void RewardAproved()
    {
        rewardedTimes++;
        PlayerPrefs.SetInt("RewardedTimes", rewardedTimes);
    }

	// Update is called once per frame
	void Update () {
		if(!rewardReady)
        {
            rewardReady = AdController.Instance.isRewardedVideoReady();

            if(rewardReady)
            {
                rewardButton.SetActive(true);
            }
        }
        else
        {
            if (frameSkip < 60)
            {
                frameSkip++;
                return;
            }

            rewardCount.text = rewardedTimes.ToString();
            frameSkip = 0;
        }
	}

    public void OnLanguageButtonClicked()
    {
        Instantiate(LangSelPrefab, canvas.transform);
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnRewardedButtonClicked()
    {
    }
}
