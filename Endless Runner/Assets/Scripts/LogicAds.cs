using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;

public class LogicAds : MonoBehaviour
{
    private BannerView bannerAd;
    private RewardBasedVideoAd rewardAd;
    private InterstitialAd interstitial;
    [SerializeField] private string rewardID = "";
    [SerializeField] private string bannerID = "";
    [SerializeField] private string appID = "";
    public Text fishText;
    private int gameAmount = 0;
    private int rewardAmount = 0;

    void Start()
    {
        RequestBannerAd();
        RequestInterstitialAd();
        AskReward();
    }

    private void Awake()
    {
        MobileAds.Initialize(appID);
    }

    void Update()
    {
        if(rewardAmount > 0)
        {
            gameAmount += rewardAmount;
            fishText.text = gameAmount.ToString();
            rewardAmount = 0;
        }
    }

    private void AskReward()
    {
        rewardAd = RewardBasedVideoAd.Instance;
        AdRequest ask = new AdRequest.Builder().Build();
        rewardAd.LoadAd(ask, rewardID);
        rewardAd.OnAdRewarded += HandleUserEarnedReward;
        rewardAd.OnAdClosed += HandleRewardedAdClosed;
    }

    public void ClickReward()
    {
       rewardAd.Show();
    }


    #region Banner Methods
    public void RequestBannerAd()
    {
        bannerAd = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = AdRequestBuild();
        bannerAd.LoadAd(request);
    }

    public void DestroyBannerAd()
    {
        if(bannerAd != null)
        {
            bannerAd.Destroy();
        }
    }
    #endregion
    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        double amount = args.Amount;
        rewardAmount = (int)amount; 
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        AskReward();
    }

    private void RequestInterstitialAd()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
        string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}




