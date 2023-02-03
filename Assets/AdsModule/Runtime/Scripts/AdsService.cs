using System;
using AdsModule.AdsProviders;
using Zenject;

 namespace AdsModule
 {
    public class AdsService : IAdsService, IInitializable
    {
        private IAdsProvider adsProvider;
        private bool isTestingMode = false;
        private AdsServiceInstaller.Settings settings;

        public AdsService(AdsServiceInstaller.Settings settings)
        {
            this.settings = settings;
            isTestingMode = settings.IsTestingMode;
        }
        
        public void Initialize()
        {
            #if UNITY_ANDROID || UNITY_IOS
            adsProvider = settings.MobileAdsProviderType switch
            {
                MobileAdsProviderType.Appodeal => new AppodealProvider(),
                _ => throw new ArgumentOutOfRangeException()
            };
            #elif UNITY_WEBGL
                adsProvider = new GameScoreProvider();
            #endif
            
            adsProvider.Initialize(isTestingMode);
        }

        public void ShowInterstitialVideo() => adsProvider.ShowInterstitialVideo();

        public void ShowRewardedVideo(Action onRewardedVideoComplete) => adsProvider.ShowRewardedVideo(onRewardedVideoComplete);
    }
 }