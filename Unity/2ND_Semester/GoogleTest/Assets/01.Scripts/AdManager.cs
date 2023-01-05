using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    private string _adID = "ca-app-pub-3940256099942544/5354046379";
    private RewardedInterstitialAd _rewardedInterstitialAd;

    private void Start() 
    {
        MobileAds.Initialize(initStatus => { });
        LoadAd();
    }

    private void LoadAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        RewardedInterstitialAd.LoadAd(_adID, request, AdLoadCallback);
    }

    private void AdLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
    {
        if (error == null) 
            _rewardedInterstitialAd = ad;
    }

    public void ShowAd()
    {
        if (_rewardedInterstitialAd != null)
        {
            _rewardedInterstitialAd.Show(UserEarnedRewardCallback);

            _rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += HandleAdFailedToPresent;
            _rewardedInterstitialAd.OnAdDidPresentFullScreenContent += HandheldAdDidPresent;
            _rewardedInterstitialAd.OnAdDidDismissFullScreenContent += HandheldAdDidDismiss;
            _rewardedInterstitialAd.OnPaidEvent += HandlePaidEvent;
        }
    }

    private void HandleAdFailedToPresent(object sender, AdErrorEventArgs e)
    {
        LoadAd();
    }

    private void HandheldAdDidPresent(object sender, EventArgs e)
    {
        LoadAd();
    }

    private void HandheldAdDidDismiss(object sender, EventArgs e)
    {
        LoadAd();
    }

    private void HandlePaidEvent(object sender, AdValueEventArgs e)
    {
        LoadAd();
    }

    private void UserEarnedRewardCallback(Reward obj)
    {
        // 광고 보상 적용
    }
}

// 구글 Ads Unity 참고 사이트 
// https://developers.google.com/admob/unity/rewarded-interstitial