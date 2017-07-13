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

    [SerializeField]
    UnityEngine.Audio.AudioMixer BGM;
    [SerializeField]
    UnityEngine.Audio.AudioMixer SE;

    [SerializeField]
    AudioSource ButtonSound;

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
        SceneManager.LoadScene("Garage");
        BGMSave();
        SESave();
    }

    public void OnRewardedButtonClicked()
    {
    }

    public float BGMVolume
    {
        set { BGM.SetFloat("BGMVolume", Mathf.Lerp(-80, 0, value)); }
    }

    public float SEVolume
    {
        set { SE.SetFloat("SEVolume", Mathf.Lerp(-80, 0, value)); ButtonSound.Play(); }
    }

    void BGMSave()
    {
        float Volume = 0;
        BGM.GetFloat("BGMVolume", out Volume);
        PlayerPrefs.SetFloat("BGMVolume", Volume);
    }
    void SESave()
    {
        float Volume = 0;
        SE.GetFloat("SEVolume", out Volume);
        PlayerPrefs.SetFloat("SEVolume", Volume);
    }
}
