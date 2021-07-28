using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAds : MonoBehaviour
{
    public string appId = "ca-app-pub-3940256099942544~3347511713";
    public string adUnitId = "ca-app-pub-3940256099942544/6300978111";

    // Use this for initialization
    void Start()
    {
        //// �A�v��ID�A ����̓e�X�g�p
        //string appId = "ca-app-pub-3940256099942544~3347511713";

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        RequestBanner();
    }
    private void RequestBanner()
    {

        //// �L�����j�b�gID ����̓e�X�g�p
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

    }


    // Update is called once per frame
    void Update()
    {

    }
}