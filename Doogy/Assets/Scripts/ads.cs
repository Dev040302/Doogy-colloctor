
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ads : MonoBehaviour,IUnityAdsListener
{
    public static ads Instance;
    public string gameId = "4468681";
    public string placementId = "Banner_Android";
    public bool testMode = true;
    GameObject endui;
    essen pg;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        Advertisement.Initialize("4468681");
        Advertisement.AddListener(this);
        ShowBanner();
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementId);
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }
    public void showad(GameObject x)
    {
        endui = x;
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            SSTools.ShowMessage("No Ads Available at the moment", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }

    }

    public void OnUnityAdsReady(string placementId) { }

    public void OnUnityAdsDidError(string message) { }

    public void OnUnityAdsDidStart(string placementId) { }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            endui.SetActive(false);
            Destroy(pg.hiten);
            pg.gameactive = true;

        }
    }

   
}