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
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

    }


    // Update is called once per frame
    void Update()
    {
        //����̉�ʂŔ�\��


    }

    void FixedUpdate()
    {
        //����̃L�����o�X���L���Ȃ�I�t�ɂ���
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

        if (OffFlag == false && bannerView == null) //�I�t�V�[���łȂ��ď����Ă�����Đ���
        {
            RequestBanner();
        }

        //for (int i = 0; i < AdOffSceneNames.Length; i++)
        //{
        //    //�V�[�����𔻕ʁB�I�t�V�[���Ȃ�I�t�ɂ���
        //    if (SceneManager.GetActiveScene().name == AdOffSceneNames[i])
        //    {
        //        bannerView.Destroy();
        //    }
        //    else if (bannerView == null)�@//�I�t�V�[���łȂ��ď����Ă�����Đ���
        //    {
        //        RequestBanner();
        //    }

        //}


    }
}