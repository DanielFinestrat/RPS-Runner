using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class GoogleMobileAdsDemoScript : MonoBehaviour {

    private BannerView bannerView;

    void Start()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-9447071254431689/9740133054";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_YOUR_IOS_AD_UNIT_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Register for ad events.
        bannerView.AdLoaded += HandleAdLoaded;
        bannerView.AdFailedToLoad += HandleAdFailedToLoad;
        bannerView.AdOpened += HandleAdOpened;
        bannerView.AdClosing += HandleAdClosing;
        bannerView.AdClosed += HandleAdClosed;
        bannerView.AdLeftApplication += HandleAdLeftApplication;

		RequestBanner();
		ShowBanner();
    }

    void RequestBanner() {
        // Request a banner ad, with optional custom ad targeting.
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .AddKeyword("game")
            .SetGender(Gender.Male)
            .SetBirthday(new DateTime(1985, 1, 1))
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
        bannerView.LoadAd(request);
    }

    void ShowBanner() {
        bannerView.Show();
    }

    void HideBanner() {
        bannerView.Hide();
    }

    #region Banner callback handlers

    public void HandleAdLoaded()
    {
        print("HandleAdLoaded event received.");
    }

    public void HandleAdFailedToLoad(string message)
    {
        print("HandleFailedToReceiveAd event received with message: " + message);
    }

    public void HandleAdOpened()
    {
        print("HandleAdOpened event received");
    }

    void HandleAdClosing ()
    {
        print("HandleAdClosing event received");
    }

    public void HandleAdClosed()
    {
        print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication()
    {
        print("HandleAdLeftApplication event received");
    }

    #endregion
}
