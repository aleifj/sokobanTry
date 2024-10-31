using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;//광고 넣을때 구글모바일 광고 에셋 설치 필요.
//https://developers.google.com/admob/android/test-ads?hl=ko
//https://github.com/googleads/googleads-mobile-unity/releases

public class Admob : MonoBehaviour//광고 연결할 때 사용하는 코드
{
    string adUnitID = "";//광고의 소스코드를 여기에 입력.
    public MapButton RewardGameObject;
    public GameObject AdLoadedStatus;
    private RewardedInterstitialAd riAd;//using문 해결되면 오류없어짐.

    public void LoadAd()
    {
        if (riAd != null)
        {
            DestroyAd();
        }

        var adRequest = new AdRequest();
        RewardedInterstitialAd.Load(adUnitId, adRequest,
            (RewardedInterstitialAd ad, LoadAdError error) =>
            {
                if (error != null) return;
                if (ad == null) return;
                riAd = ad;
                RegisterEventHandlers(ad);
                AdLoadedStatus?.SetActive(true);
                RewardGameObject.SetNumberAlpha();
            });
    }

    public void ShowAd()
    {
        if (riAd != null && riAd.CanShowAd())
        {
            riAd.Show((Reward reward) =>
            {
                RewardGameObject.RewardAd();
            });
        }
        AdLoadedStatus?.SetActive(false);
    }

    public void DestroyAd()
    {
        if (riAd != null)
        {
            riAd.Destroy();
            riAd = null;
        }
        AdLoadedStatus?.SetActive(false);
    }

    public void LogResponseInfo()
    {
        if (riAd != null)
        {
            var responseInfo = riAd.GetResponseInfo();
            UnityEngine.Debug.Log(responseInfo);
        }
    }

    protected void RegisterEventHandlers(RewardedInterstitialAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) => { };
        ad.OnAdImpressionRecorded += () => { };
        ad.OnAdClicked += () => { };
        ad.OnAdFullScreenContentOpened += () => { };
        ad.OnAdFullScreenContentClosed += () => { };
        ad.OnAdFullScreenContentFailed += (AdError error) => { };
    }
}
