using System;

namespace GRV.AdsModule.AdsProviders
{
    public interface IAdsProvider
    {
        public void Initialize(bool isTestingMode = default);
        public void ShowInterstitialVideo();
        public void ShowRewardedVideo(Action onRewardedVideoComplete);
    }
}