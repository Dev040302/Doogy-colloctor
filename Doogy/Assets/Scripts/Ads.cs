using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour
{
    private BannerView bannerView;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RequestBanner()
    {

        this.bannerView = new BannerView("ca-app-pub-2670894776494091/4085258702", AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

    }
}
