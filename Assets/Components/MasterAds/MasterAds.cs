using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class MasterAds : MonoBehaviour
{

    private BannerView bannerView;
    [SerializeField] private string bannerAdUnitId;
    private InterstitialAd interstitial;
    [SerializeField] private string interstitialAdUnitId;
    private RewardedAd rewardedAd;
    [SerializeField] private string rewardedAdUnitId;
    [SerializeField] private Button buttonInterstitialAd;
    [SerializeField] private Button ButtonRewardedAds;
    [SerializeField] private Button ButtonBannerAdsClose;
    
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.LoadAdError.GetMessage());
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.AdError.GetMessage());
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        ButtonRewardedAds.gameObject.SetActive(false);
        RequestReward();
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
    private void RequestReward(){
        this.rewardedAd = new RewardedAd(rewardedAdUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        if(this.rewardedAd.IsLoaded()){
            ButtonRewardedAds.gameObject.SetActive(true);
        }
    }
    public void ShowRewardedAds(){
        this.rewardedAd.Show();
    }
    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        
        this.ButtonBannerAdsClose.gameObject.SetActive(true);
    }
    
    private void OnCloseInterstitialAds(object sender, EventArgs args){
        this.buttonInterstitialAd.gameObject.SetActive(false);
        this.RequestInterstitial();
    }
    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitialAdUnitId);
        this.interstitial.OnAdClosed += OnCloseInterstitialAds;
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.interstitial.LoadAd(request);
        if(this.interstitial.IsLoaded())
        {
            this.buttonInterstitialAd.gameObject.SetActive(true);
        }
    }
    public void ShowInterstitialAds(){
        this.interstitial.Show();
    }

    public void OnCloseAdsBanner(){
        bannerView.Hide();
    }


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
        this.RequestInterstitial();
        this.RequestReward();
        
    }
}
