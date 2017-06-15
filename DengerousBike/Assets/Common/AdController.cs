using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : Singleton<AdController>
{
    public delegate void RewardAproved();

    RewardAproved rewardAprovedDel = null;

    void Start()
    {
        AppLovin.SetSdkKey("cBmxxgR0WEQ2g9uRR0mbcORZUeFHePvFbfAXKcTsrzvW7nzZniAN6cyaFCsucm8DPJllwHbmFUHNFFx0y5O2hL");
        AppLovin.InitializeSdk();
        AppLovin.LoadRewardedInterstitial();
        AppLovin.SetUnityAdListener(gameObject.name);
    }

    public bool isRewardedVideoReady()
    {
        return AppLovin.IsIncentInterstitialReady();
    }

    public void ShowRewardedVideo()
    {
        if(AppLovin.IsIncentInterstitialReady())
        {
            AppLovin.ShowRewardedInterstitial();
        }
    }

    public void SetRewardAprovedDelegate(RewardAproved rewardDel)
    {
        rewardAprovedDel = rewardDel;
    }

    void onAppLovinEventReceived(string ev)
    {
        if(ev.Contains("REWARDAPPROVEDINFO"))
        {
            if(rewardAprovedDel != null)
            rewardAprovedDel();
        }
    }
}
