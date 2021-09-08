using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    public bool bonusVideo = false;
    public bool restartVideo = false;

    public bool adsVideoFinished = false;

    public Button viewAdsButton;

    private const string APP_KEY = "04356c5bee252317c91331ea16eb2bface7929ac25826910";
    void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (adsVideoFinished && restartVideo)
        {
            //GamePlayManager.instance.AdShowSucessfully();
            restartVideo = false;
        }

        if (adsVideoFinished && bonusVideo)
        {
            //GameManager.Candy += 50;
            bonusVideo = false;
        }

        adsVideoFinished = false;

        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            viewAdsButton.interactable = true;
    }

    private void Awake()
    {
        instance = this;
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        adsVideoFinished = true;

        if (restartVideo && bonusVideo)
        {
            bonusVideo = false;
        }

        if (!restartVideo && !bonusVideo)
        {
            bonusVideo = true;
        }

        Debug.Log("video vkluch bonus " + bonusVideo);
        Debug.Log("video vkluch restart " + restartVideo);
    }

    private void Initialize()
    {
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
       // Appodeal.setRewardedVideoCallbacks(this);
    }


    public void ShowInterstitial()
    {
        Debug.LogError("Реклама");
        Debug.Log(PlayerPrefs.GetInt("removeads").ToString());
        Debug.Log(PlayerPrefs.HasKey("ads").ToString());
        if (PlayerPrefs.HasKey("ads") == false && PlayerPrefs.GetInt("removeads",0)==0)
        {
            
            if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
                Appodeal.show(Appodeal.INTERSTITIAL);

            //else if (Application.internetReachability == NetworkReachability.NotReachable)
              //  Toast.instance.ShowMessage("??????????? ??????????? ? ?????????");
        }
    }

    public void ShowRewardedVideo()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        //if (Application.internetReachability == NetworkReachability.NotReachable)
          //  Toast.instance.ShowMessage("??????????? ??????????? ? ?????????");
    }

    public void ShowRewardedVideoInShop()
    {
        bonusVideo = true;
        ShowRewardedVideo();
    }

    public void ShowRewardedVideoRestart()
    {
        restartVideo = true;
        ShowRewardedVideo();
    }

    #region RewardedVideo Events

    public void onRewardedVideoLoaded(bool precache)
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoShowFailed()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoShown()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoClosed(bool finished)
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoClicked()
    {
        throw new System.NotImplementedException();
    }

    #endregion

    #region Interstitial Events

    public void onInterstitialLoaded(bool isPrecache)
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShowFailed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShown()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialClosed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialClicked()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialExpired()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
