using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class GoogleMobileAdsInterstitial : MonoBehaviour
{
  public InterstitialAd interstitial;
  
  private static GoogleMobileAdsInterstitial _instance;
  public static GoogleMobileAdsInterstitial Instance { get { return _instance; } }

    public void Start()
      {
          if (_instance != null && _instance != this)
          {
              Destroy(gameObject);
          } 
          else 
          {
              _instance = this;
          }
          
  #if UNITY_ANDROID
          string appId = "ca-app-pub-1278119892895852/5115480793";
          
  #elif UNITY_IPHONE
              string appId = "ca-app-pub-1278119892895852/1122171565";
  #else
              string appId = "unexpected_platform";
  #endif
  
          
          // Initialize the Google Mobile Ads SDK.
          MobileAds.Initialize(appId);
  
          this.RequestInterstitial();
      }
  public void RequestInterstitial()
  {
      
     #if UNITY_ANDROID
             string adUnitId = "ca-app-pub-3940256099942544/1033173712";
         #elif UNITY_IPHONE
             string adUnitId = "ca-app-pub-3940256099942544/4411468910";
         #else
             string adUnitId = "unexpected_platform";
         #endif
     
      if (this.interstitial != null)
      {
          
          this.interstitial.Destroy();
      }

      
         // Initialize an InterstitialAd.
         this.interstitial = new InterstitialAd(adUnitId);
         
         // Create an empty ad request.
         AdRequest request = new AdRequest.Builder().Build();
        
         // Load the interstitial with the request.
         this.interstitial.LoadAd(request);
         

  }

 
  }
