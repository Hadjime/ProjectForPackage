using System;

namespace AdsModule
{
    public interface IAdsService
    {
        public void ShowInterstitialVideo();
        public void ShowRewardedVideo(Action onRewardedVideoComplete);
    }
}