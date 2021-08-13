using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GoogleAds : MonoBehaviour
{
    public string appId = "ca-app-pub-3940256099942544~3347511713";
    public string adUnitId = "ca-app-pub-3940256099942544/6300978111";
    //public string[] AdOffSceneNames;
    public GameObject[] AdOffObjects;
    private bool OffFlag = false;
    BannerView bannerView;
    AdRequest request;


    // Use this for initialization

    void Awale()
    {


    }

    void Start()
    {
        //// アプリID、 これはテスト用
        //string appId = "ca-app-pub-3940256099942544~3347511713";

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        RequestBanner();
    }
    private void RequestBanner()
    {

        //// 広告ユニットID これはテスト用
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

    }


    // Update is called once per frame
    void Update()
    {
        //特定の画面で非表示


    }

    void FixedUpdate()
    {
        //特定のキャンバスが有効ならオフにする
        for (int i = 0; i < AdOffObjects.Length; i++)
        {
            if (AdOffObjects[i].activeSelf)
            {
                OffFlag = true;
                break;
            }
            else
            {
                OffFlag = false;
            }

        }

        if (OffFlag == true && bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }

        if (OffFlag == false && bannerView == null) //オフシーンでなくて消えていたら再生成
        {
            RequestBanner();
        }

        //for (int i = 0; i < AdOffSceneNames.Length; i++)
        //{
        //    //シーン名を判別。オフシーンならオフにする
        //    if (SceneManager.GetActiveScene().name == AdOffSceneNames[i])
        //    {
        //        bannerView.Destroy();
        //    }
        //    else if (bannerView == null)　//オフシーンでなくて消えていたら再生成
        //    {
        //        RequestBanner();
        //    }

        //}


    }
}