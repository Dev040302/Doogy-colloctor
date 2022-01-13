using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour
{
    public static Ads Instance;
    private BannerView bannerView;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RequestBanner()
    {

        this.bannerView = new BannerView("ca-app-pub-3940256099942544/6300978111", AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

    }
}
