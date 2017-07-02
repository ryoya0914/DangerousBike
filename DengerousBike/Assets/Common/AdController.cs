using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : Singleton<AdController>
{
    bool rewarderFound = false;
    public delegate void RewarderDelegate();
    public RewarderDelegate m_rewardDelegate;

    void Start()
    {
        m_rewardDelegate = EmptyMothod;

#if !UNITY_EDITOR
        AppLovin.SetSdkKey("cBmxxgR0WEQ2g9uRR0mbcORZUeFHePvFbfAXKcTsrzvW7nzZniAN6cyaFCsucm8DPJllwHbmFUHNFFx0y5O2hL");
        AppLovin.InitializeSdk();
        AppLovin.LoadRewardedInterstitial();
        AppLovin.SetUnityAdListener(gameObject.name);
#endif
    }

    void EmptyMothod()
    {
        Debug.Log("Reward was not set");
    }

    public void FindRewarder(RewarderDelegate rewarder)
    {
        rewarder();
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
            OnVideoSuccess();
        }
        else if (ev.Contains("VIDEOBEGAN"))
        {
            //OnVideoStart();
        }
        else if (ev.Contains("REWARDAPPROVED"))
        {
            //OnVideoSuccess();
        }
        else if (ev.Contains("REWARDREJECTED"))
        {
            //OnVideoFailure();
        }
        else if (ev.Contains("VIDEOSTOPPED"))
        {
            //OnVideoClose();
        }
    }

    void OnVideoStart()
    {

    }

    void OnVideoSuccess()
    {
        m_rewardDelegate();
    }

    void OnVideoFailure()
    {

    }

    void OnVideoClose()
    {

    }
}
