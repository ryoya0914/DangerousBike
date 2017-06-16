using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : Singleton<AdController>
{
    OptionScene optionScene;
    bool rewarderFound = false;

    void Start()
    {
#if !UNITY_EDITOR
        AppLovin.SetSdkKey("cBmxxgR0WEQ2g9uRR0mbcORZUeFHePvFbfAXKcTsrzvW7nzZniAN6cyaFCsucm8DPJllwHbmFUHNFFx0y5O2hL");
        AppLovin.InitializeSdk();
        AppLovin.LoadRewardedInterstitial();
        AppLovin.SetUnityAdListener(gameObject.name);
#endif
    }

    public void FindRewarder()
    {
        optionScene = GameObject.Find("OptionScene").GetComponent<OptionScene>();

        if(optionScene)
        {
            rewarderFound = true;
        }
    }

    public bool isRewardedVideoReady()
    {
#if UNITY_EDITOR
        return false;
#else
        return AppLovin.IsIncentInterstitialReady();
#endif
    }

    public void ShowRewardedVideo()
    {
        if (AppLovin.IsIncentInterstitialReady())
        {
            AppLovin.ShowRewardedInterstitial();
        }
    }

    void onAppLovinEventReceived(string ev)
    {
        if (ev.Contains("HIDDENREWARDED"))
        {
            AppLovin.LoadRewardedInterstitial();
        }
        else if (ev.Contains("VIDEOBEGAN"))
        {
            OnVideoStart();
        }
        else if (ev.Contains("REWARDAPPROVED"))
        {
            OnVideoSuccess();
        }
        else if (ev.Contains("REWARDREJECTED"))
        {
            OnVideoFailure();
        }
        else if (ev.Contains("VIDEOSTOPPED"))
        {
            OnVideoClose();
        }
    }

    void OnVideoStart()
    {

    }

    void OnVideoSuccess()
    {
        if(rewarderFound)
        {
            optionScene.RewardAproved();
            rewarderFound = false;
        }
    }

    void OnVideoFailure()
    {

    }

    void OnVideoClose()
    {

    }
}
