using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class ManagerAdo : MonoBehaviour
{
    public Text statusT;
    

    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;

    void Start() {

        // this is when you publish your app
        //MobileAds.Initialize(APP_ID);

        this.rewardVideoAd = RewardBasedVideoAd.Instance;



        // Called when an ad request has successfully loaded.
        rewardVideoAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardVideoAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardVideoAd.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardVideoAd.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardVideoAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardVideoAd.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardVideoAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;



        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();


    }




    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        RequestVideoAD();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //string type = args.Type;
        //double amount = args.Amount;
        //MonoBehaviour.print(
        //    "HandleRewardBasedVideoRewarded event received for "
        //                + amount.ToString() + " " + type);
        statusT.text = "I'm rich! :D";
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }





void RequestBanner() {

        string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Bottom);

        // FOR REAL APP
        //AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        AdRequest adRequest = new AdRequest.Builder()
        .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);

    }

    void RequestInterstitial() {

        string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        interstitialAd = new InterstitialAd(interstitial_ID);

        // FOR REAL APP
        //AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        AdRequest adRequest = new AdRequest.Builder()
        .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        interstitialAd.LoadAd(adRequest);

    }

    void RequestVideoAD() {

        string video_ID = "ca-app-pub-3940256099942544/5224354917";
        rewardVideoAd = RewardBasedVideoAd.Instance;

        // FOR REAL APP
        //AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        AdRequest adRequest = new AdRequest.Builder()
        .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);

    }

    public void Display_Banner() {
        bannerAD.Show();
    }

    public void Display_InterstitialAD() {

        if (interstitialAd.IsLoaded()) {
            interstitialAd.Show();
        }

    }

    public void Display_Reward_Video() { 

        if(rewardVideoAd.IsLoaded()) {
            rewardVideoAd.Show();
        }

    }
}
