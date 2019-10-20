using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleMobileAdsBanner : MonoBehaviour
{
    private BannerView bannerView;
       
    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-1278119892895852~2246840533";
        
#elif UNITY_IPHONE
            string appId = "ca-app-pub-1278119892895852~2813816747";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
 #if UNITY_ANDROID
      string adUnitId = "ca-app-pub-1278119892895852/2602063750";
  #elif UNITY_IPHONE
      string adUnitId = "ca-app-pub-1278119892895852/5564103167";
  #else
      string adUnitId = "unexpected_platform";
  #endif

        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
        
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
  
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
        

    }

    
 
}
