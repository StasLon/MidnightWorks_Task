using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeAds : MonoBehaviour
{

    public string appKey;

    private void Awake()
    {
        IronSource.Agent.init(appKey);
    }

    private void OnApplicationPause(bool pause)
    {
        IronSource.Agent.onApplicationPause(pause);
    }

    private void Start()
    {
        LoadBanner();
    }


    public void LoadBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }

}
