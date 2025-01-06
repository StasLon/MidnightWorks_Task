using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePointsReward : MonoBehaviour
{
    public string appKey;

    private void Start()
    {
        IronSource.Agent.shouldTrackNetworkState(true);
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdClosedEvent += RevardedVideoAdClosedEvent;

    }

    public void Rewarded()
    {
        IronSource.Agent.showRewardedVideo();
    }

    private void RevardedVideoAdClosedEvent()
    {
        IronSource.Agent.init(appKey, IronSourceAdUnits.REWARDED_VIDEO);
        IronSource.Agent.shouldTrackNetworkState(true);
    }

    private void  RewardedVideoAvailabilityChangedEvent(bool available)
    {
        bool revardedVideoAvailability = available;
    }

    private void OnDestroy()
    {
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent -= RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdClosedEvent -= RevardedVideoAdClosedEvent;
    }


}
